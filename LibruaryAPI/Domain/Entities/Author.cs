namespace LibruaryAPI.Domain.Entities
{
    /// <summary>
    /// Сущность автор.
    /// </summary>
    public class Author
    {
        /// <summary>
        /// Идентификатор автора.
        /// </summary>
        public int AuthorId { get; set; }
        /// <summary>
        /// Имя автора.
        /// </summary>
        public required string FirstName {  get; set; }
        /// <summary>
        /// Фамилия автора.
        /// </summary>
        public required string LastName { get; set; }
        /// <summary>
        /// СТрана автора.
        /// </summary>
        public required string Country { get; set; }
        /// <summary>
        /// Дата рождения автора.
        /// </summary>
        public DateTime BirthDate { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();

    }
}
