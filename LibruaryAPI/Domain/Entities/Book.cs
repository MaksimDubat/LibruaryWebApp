namespace LibruaryAPI.Domain.Entities
{
    /// <summary>
    /// Сущность книги.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Идентификатор книги.
        /// </summary>
        public int BookId { get; set; }
        /// <summary>
        /// Уникальный код, генерируемый для книги.
        /// </summary>
        public required string ISBN { get; set; }
        /// <summary>
        /// Название книги.
        /// </summary>
        public required string Title { get; set; }
        /// <summary>
        /// Описание книги.
        /// </summary>
        public required string Description { get; set; }
        /// <summary>
        /// Когда взяли книгу.
        /// </summary>
        public DateTime TakenAt { get; set; }
        public int AuthorId { get; set; }
        public required Author Author { get; set; } 
    }
}
