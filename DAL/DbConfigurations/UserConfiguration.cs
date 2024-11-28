using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SF.PJ03.Task25._7._1.DAL.Entities;

namespace SF.PJ03.Task25._7._1.DAL.Database.DAL.DbConfigurations;

/// <summary>
/// Конфигурация сущности `User` для настройки таблицы в базе данных.
/// Настраивает имя таблицы, ограничения и свойства.
/// </summary>
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(u => u.Id);

        // Свойства Title и Genre с ограничениями
        builder.Property(u => u.Name).HasMaxLength(100).IsRequired();

        builder.Property(u => u.Email).HasMaxLength(100).IsRequired();
    }
}