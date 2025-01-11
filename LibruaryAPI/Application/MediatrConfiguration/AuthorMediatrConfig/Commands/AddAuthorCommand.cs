using LibruaryAPI.Domain.Entities;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Commands
{
    /// <summary>
    /// МОдель команды добавления автора.
    /// </summary>
    public class AddAuthorCommand : IRequest<Author>
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
        public AddAuthorCommand(string firstName, string lastName, string country, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Country = country;
            BirthDate = birthDate;
        }
    }
}
