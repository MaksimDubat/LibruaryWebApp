namespace LibruaryAPI.Application.Contcracts.DTOs
{
    /// <summary>
    /// DTO для сущности Author
    /// </summary>
    public class AuthorDto
    {
        /// <summary>
        /// Имя автора.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия автора.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Страна автора.
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Дата рождения автора.
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Книги, написаные автором.
        /// </summary>
        public List<string> BookTitles { get; set; }
    }
}
