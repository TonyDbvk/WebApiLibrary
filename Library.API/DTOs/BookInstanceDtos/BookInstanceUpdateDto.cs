namespace Library.API.DTOs.BookInstanceDtos
{
    public class BookInstanceUpdateDto
    {
        public DateTime BorrowedAt { get; set; } // Дата, когда книга была взята
        public DateTime ReturnBy { get; set; }   // Дата, когда книгу нужно вернуть
    }

}
