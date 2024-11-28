using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SF.PJ03.Task25._7._1.DAL.Entities;

namespace SF.PJ03.Task25._7._1.DAL.Database;

/// <summary>
/// Контекст базы данных приложения, содержащий DbSet для пользователей, книг, авторов и жанров.
/// Настраивает подключение, модель базы данных и логирование.
/// </summary>
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

        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppContext).Assembly);
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