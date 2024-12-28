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
        public int Id { get; set; }
        /// <summary>
        /// Уникальный код, генерируемый для книги.
        /// </summary>
        public string ISBN { get; set; } = string.Empty;
        /// <summary>
        /// Название книги.
        /// </summary>
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// Описание книги.
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Автор книги.
        /// </summary>
        public string Author { get; set; } = string.Empty;
        /// <summary>
        /// Когда взяли книгу.
        /// </summary>
        public DateTime TakenAt { get; set; }

    }
}
