namespace Library.API.DTOs.BookInstanceDtos
{
    public class BookInstanceReadDto
    {
        public Guid Id { get; set; }            // Уникальный идентификатор экземпляра книги
        public Guid BookId { get; set; }         // Идентификатор книги
        public Guid UserId { get; set; }         // Идентификатор пользователя, который взял книгу
        public DateTime BorrowedAt { get; set; } // Дата, когда книгу взяли
        public DateTime ReturnBy { get; set; }   // Дата, когда книгу нужно вернуть
        public string BookTitle { get; set; }    // Название книги (опционально для удобства клиента)
        public string UserName { get; set; }     // Имя пользователя (опционально для удобства клиента)
    }

}
