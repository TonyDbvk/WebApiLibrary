using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.DataAccess.Configuration
{
    public class BookInstanceConfiguration : IEntityTypeConfiguration<BookInstance>
    {
        public void Configure(EntityTypeBuilder<BookInstance> builder)
        {
            // Установка ключа
            builder.HasKey(bi => bi.Id);

            // Установка связи "многие к одному" с книгой
            builder.HasOne(bi => bi.Book)
                   .WithMany() // No navigation property in Book
                   .HasForeignKey(bi => bi.BookId)
                   .OnDelete(DeleteBehavior.Restrict); // Предотвращаем удаление книги, пока она взята

            // Установка связи "многие к одному" с пользователем
            builder.HasOne(bi => bi.User)
                   .WithMany(u => u.BookInstances)
                   .HasForeignKey(bi => bi.UserId)
                   .OnDelete(DeleteBehavior.Restrict); // Предотвращаем удаление пользователя, пока у него есть книги
        }
    }
}
