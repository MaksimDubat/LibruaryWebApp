namespace LibruaryAPI.Application.Contcracts.DTOs
{
    /// <summary>
    /// DTO для корзины пользователя.
    /// </summary>
    public class CartDto
    {
        /// <summary>
        /// Идентификатор корзины.
        /// </summary>
        public int CartId { get; set; }
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Идентификатор книги
        /// </summary>
        public int BookId { get; set; }
        /// <summary>
        /// Название книги.
        /// </summary>
        public string BookTitle { get; set; }
        /// <summary>
        /// Дата взятия книги.
        /// </summary>
        public DateTime TakenAt { get; set; }
        /// <summary>
        /// Количество дней хранения.
        /// </summary>
        public int StorageDays { get; set; }
        /// <summary>
        /// Статус корзины.
        /// </summary>
        public string CartStatus { get; set; } = "Добавлено!";
    }
}
