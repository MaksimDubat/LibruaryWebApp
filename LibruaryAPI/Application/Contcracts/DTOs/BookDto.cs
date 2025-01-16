namespace LibruaryAPI.Application.Contcracts.DTOs
{
    /// <summary>
    /// DTO для сущности Book.
    /// </summary>
    public class BookDto
    {
        /// <summary>
        /// Идентификатор книги.
        /// </summary>
        public int BookId { get; set; }
        /// <summary>
        /// ISBN книги.
        /// </summary>
        public string ISBN { get; set; }
        /// <summary>
        /// Название книги.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Описание книги.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Дата взятия книги.
        /// </summary>
        public DateTime TakenAt { get; set; }
        /// <summary>
        /// Идентификатор автора.
        /// </summary>
        public int AuthorId { get; set; }
        /// <summary>
        /// Имя автора.
        /// </summary>
        public string AuthorName { get; set; }
        /// <summary>
        /// Доступна ли книга.
        /// </summary>
        public bool IsAvailable { get; set; }
        /// <summary>
        /// Изображение книги.
        /// </summary>
        public string Image {  get; set; }
        /// <summary>
        /// Количество книг.
        /// </summary>
        public int Amount { get; set; }
    }
}
