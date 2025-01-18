using LibruaryAPI.Application.Contcracts.DTOs;
using LibruaryAPI.Domain.Entities;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Queries
{
    /// <summary>
    /// Получение всех книг. 
    /// </summary>
    public class GetAllQuery : IRequest<IEnumerable<BookDto>>
    {
    }
}
