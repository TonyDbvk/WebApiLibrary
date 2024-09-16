namespace Library.API.DTOs.BookInstanceDtos
{
    public class BookInstanceCreateDto
    {
        public Guid BookId { get; set; }         // Идентификатор книги, которую пользователь берет
        public Guid UserId { get; set; }         // Идентификатор пользователя, который берет книгу
        public DateTime BorrowedAt { get; set; } // Дата, когда книга взята (по умолчанию может быть текущей датой)
        public DateTime ReturnBy { get; set; }   // Дата, когда книгу нужно вернуть
    }

}
