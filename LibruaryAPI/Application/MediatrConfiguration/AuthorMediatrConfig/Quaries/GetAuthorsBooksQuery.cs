using LibruaryAPI.Domain.Entities;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Quaries
{
    /// <summary>
    /// Запрос на получение книг определнного автора.
    /// </summary>
    public class GetAuthorsBooksQuery : IRequest<IEnumerable<Book>>
    {
        /// <summary>
        /// Имя автора.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия автора.
        /// </summary>
        public string LastName { get; set; }
        public GetAuthorsBooksQuery(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
