namespace Library.API.DTOs.BookInstanceDtos
{
    public class UserBookInstance
    {
        public string BookTitle { get; set; }
        public string AuthorName { get; set; }
        public DateTime BorrowedAt { get; set; } // Дата, когда книга была взята
        public DateTime ReturnBy { get; set; }   // Дата, когда книгу нужно вернуть

    }

}
