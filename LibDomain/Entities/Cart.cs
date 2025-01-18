namespace LibruaryAPI.Domain.Entities
{
    /// <summary>
    /// Сущность корзины для хранения данных о книгах на руках пользователя.
    /// </summary>
    public class Cart
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
        /// Связь с пользователем.
        /// </summary>
        public required AppUsers User { get; set; }
        /// <summary>
        /// Идентификатор книги.
        /// </summary>
        public int BookId { get; set; }
        /// <summary>
        /// Связь с книгой.
        /// </summary>
        public Book Book { get; set; }
        /// <summary>
        /// Дата взятия книги.
        /// </summary>
        public DateTime TakenAt { get; set; }
        /// <summary>
        /// Количество дней хранения.
        /// </summary>
        public int StorageDays { get; set; }
        /// <summary>
        /// Статус в корзине.
        /// </summary>
        public string CartStatus { get; set; } = "Добавлено!";
    }
}
