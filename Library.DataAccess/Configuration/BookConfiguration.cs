using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.DataAccess.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            // Установка ключа
            builder.HasKey(b => b.Id);

            // Установка свойства Title как обязательного (NOT NULL)
            builder.Property(b => b.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            // Установка свойства ISBN как обязательного и уникального
            builder.Property(b => b.ISBN)
                   .IsRequired()
                   .HasMaxLength(13);

            // Конфигурация связи "многие к одному" без указания навигационного свойства
            builder.HasOne<Author>() // Указываем тип Author, но не навигационное свойство
                   .WithMany(a => a.Books)
                   .HasForeignKey(b => b.AuthorId);
        }
    }
}
