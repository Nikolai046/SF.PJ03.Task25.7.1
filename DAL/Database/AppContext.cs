using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SF.PJ03.Task25._7._1.DAL.Entities;

namespace SF.PJ03.Task25._7._1.DAL.Database;

public class AppContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Genre> Genres { get; set; }

    private readonly string connectionString;

    public AppContext()
    {
       connectionString = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // Указываем текущий каталог
            .AddJsonFile("appsettings.json") // Подключаем appsettings.json
            .Build()
            .GetConnectionString("Database");
        
        Database.EnsureDeleted();
        Database.EnsureCreated();

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entityBuilder =>
        {
            entityBuilder.ToTable("Books").HasKey(b => b.Id);

            // Свойства Title и Genre с ограничениями
            entityBuilder.Property(b => b.Title).HasMaxLength(100).IsRequired();

            // Связь "много ко многим" с жанрами
            entityBuilder.HasMany(b => b.Genres).WithMany(a => a.Books);

            // Связь "много ко многим" с авторами
            entityBuilder.HasMany(b => b.Authors).WithMany(a => a.Books);

            // Связь "один ко многим" с пользователями
            entityBuilder.HasOne(b => b.User).WithMany(u => u.Books).HasForeignKey(b => b.UserId);
        });

        modelBuilder.Entity<User>(entityBuilder =>
        {
            entityBuilder.ToTable("Users").HasKey(u => u.Id);

            // Свойства Title и Genre с ограничениями
            entityBuilder.Property(u => u.Name).HasMaxLength(100).IsRequired();

            entityBuilder.Property(u => u.Email).HasMaxLength(100).IsRequired();

        });

        modelBuilder.Entity<Author>(entityBuilder =>
        {
            entityBuilder.ToTable("Authors").HasKey(a => a.Id);

            // Свойства Title и Genre с ограничениями
            entityBuilder.Property(a => a.Name).HasMaxLength(100).IsRequired();
            
        });

        modelBuilder.Entity<Genre>(entityBuilder =>
        {
            entityBuilder.ToTable("Genres").HasKey(a => a.Id);

            // Свойства Title и Genre с ограничениями
            entityBuilder.Property(a => a.Name).HasMaxLength(100).IsRequired();

        });

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                .AddDebug()
                .SetMinimumLevel(LogLevel.Information);
        });
        optionsBuilder.UseSqlServer(connectionString)
            .UseLoggerFactory(loggerFactory)
            .EnableSensitiveDataLogging();
    }
}

