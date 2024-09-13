﻿using Library.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Library.DataAccess.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            // Установка ключа
            builder.HasKey(a => a.Id);

            // Установка свойства FirstName как обязательного
            builder.Property(a => a.FirstName)
                   .IsRequired()
                   .HasMaxLength(100);

            // Установка свойства LastName как обязательного
            builder.Property(a => a.LastName)
                   .IsRequired()
                   .HasMaxLength(100);

            // Установка свойства Country
            builder.Property(a => a.Country)
                   .HasMaxLength(100);

            // Установка связи "один ко многим" с книгами, но без указания навигационного свойства
            builder.HasMany(a => a.Books)
                   .WithOne() // Убираем указание на навигационное свойство в Book
                   .HasForeignKey(b => b.AuthorId);
        }
    }
}
