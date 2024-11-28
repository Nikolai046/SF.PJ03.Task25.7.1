using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SF.PJ03.Task25._7._1.DAL.Entities;

namespace SF.PJ03.Task25._7._1.DAL.Database.DAL.DbConfigurations;

/// <summary>
/// Конфигурация сущности `Book` для настройки таблицы в базе данных.
/// Настраивает имя таблицы, ограничения и свойства.
/// </summary>
public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books").HasKey(b => b.Id);

        // Свойства Title и Genre с ограничениями
        builder.Property(b => b.Title).HasMaxLength(100).IsRequired();

        // Связь "много ко многим" с жанрами
        builder.HasMany(b => b.Genres).WithMany(a => a.Books);

        // Связь "много ко многим" с авторами
        builder.HasMany(b => b.Authors).WithMany(a => a.Books);

        // Связь "один ко многим" с пользователями
        builder.HasOne(b => b.User).WithMany(u => u.Books).HasForeignKey(b => b.UserId);
    }
}