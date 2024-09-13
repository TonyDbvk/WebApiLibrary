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

            // Установка связи многие к одному с User
            builder.HasOne<User>() // Указываем тип User, но не навигационное свойство
                   .WithMany()
                   .HasForeignKey(bi => bi.UserId)
                   .OnDelete(DeleteBehavior.SetNull); // При удалении пользователя UserId будет установлен в null

            // Установка связи многие к одному с Book
            builder.HasOne<Book>() // Указываем тип Book, но не навигационное свойство
                   .WithMany()
                   .HasForeignKey(bi => bi.BookId);
        }
    }
}
