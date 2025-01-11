using LibruaryAPI.Domain.Entities;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Commands
{
    /// <summary>
    /// Команда для обновления автора.
    /// </summary>
    public class UpdateAuthorCommand : IRequest<Author>
    {
        /// <summary>
        /// Идентификатор автора.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Сущность автора.
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
        public UpdateAuthorCommand(int id, string firstName, string lastName, string country, DateTime birthDate)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Country = country;
            BirthDate = birthDate;
        }
    }
}
