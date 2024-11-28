using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SF.PJ03.Task25._7._1.DAL.Entities;

namespace SF.PJ03.Task25._7._1.DAL.Database.DAL.DbConfigurations;

/// <summary>
/// Конфигурация сущности `Genre` для настройки таблицы в базе данных.
/// Настраивает имя таблицы, ограничения и свойства.
/// </summary>
public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.ToTable("Genres").HasKey(a => a.Id);

        // Свойства Title и Genre с ограничениями
        builder.Property(a => a.Name).HasMaxLength(100).IsRequired();
    }
}