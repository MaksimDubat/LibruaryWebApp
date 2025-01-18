using LibruaryAPI.Application.Contcracts.DTOs;
using LibruaryAPI.Domain.Entities;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Queries
{
    /// <summary> 
    /// Очередь для получения книги по ISBN
    /// </summary>
    public class GetByIsbnQuery : IRequest<BookDto>
    {
        /// <summary>
        /// ISBN книги.
        /// </summary>
        public string ISBN { get; set; }
        public GetByIsbnQuery(string Isbn)
        {
            ISBN = Isbn;
        }
    }
}
