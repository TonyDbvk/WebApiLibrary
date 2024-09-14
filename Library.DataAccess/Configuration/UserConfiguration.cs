using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.DataAccess.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Установка ключа
            builder.HasKey(u => u.Id);

            // Установка свойства FirstName как обязательного (NOT NULL)
            builder.Property(u => u.FirstName)
                   .IsRequired()
                   .HasMaxLength(50);

            // Установка свойства LastName как обязательного (NOT NULL)
            builder.Property(u => u.LastName)
                   .IsRequired()
                   .HasMaxLength(50);

            // Установка свойства UserName как обязательного (NOT NULL)
            builder.Property(u => u.UserName)
                   .IsRequired()
                   .HasMaxLength(256);

            // Установка свойства Email как обязательного (NOT NULL)
            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(256);

            // Установка свойства PasswordHash как обязательного (NOT NULL)
            builder.Property(u => u.PasswordHash)
                   .IsRequired();

            // Установка свойства SecurityStamp как обязательного (NOT NULL)
            builder.Property(u => u.SecurityStamp)
                   .IsRequired();

            // Установка связи один ко многим для BorrowedBookInstances
            //builder.HasMany<BookInstance>()
            //       .WithOne()
            //       .HasForeignKey(bi => bi.UserId)
            //       .OnDelete(DeleteBehavior.SetNull); // При удалении пользователя UserId будет установлен в null
        }
    }
}
