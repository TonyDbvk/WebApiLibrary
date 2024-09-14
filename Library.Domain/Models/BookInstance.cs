using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Models
{
    public class BookInstance
    {
        public Guid Id { get; set; } // Уникальный идентификатор экземпляра книги
        public Guid BookId { get; set; } // Идентификатор книги
        public Book Book { get; set; }
        public Guid? UserId { get; set; } // Идентификатор пользователя, взявшего книгу (может быть null)
        public bool IsAvailable { get; set; } = true; // Доступен ли экземпляр
        public DateTime? BorrowedAt { get; set; }
        public DateTime? ReturnBy { get; set; }
    }

}
