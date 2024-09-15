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

            builder.HasIndex(b => b.ISBN)
                   .IsUnique();

            // Конфигурация связи "многие к одному" с автором
            builder.HasOne(b => b.Author) // Указываем навигационное свойство
                   .WithMany(a => a.Books)
                   .HasForeignKey(b => b.AuthorId);
        }
    }
}
