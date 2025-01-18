using AutoMapper;
using LibruaryAPI.Application.Contcracts.DTOs;
using LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Queries;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Domain.Interfaces;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик запроса на получение книги по ISBN.
    /// </summary>
    public class GetByIsbnQueryHandler : IRequestHandler<GetByIsbnQuery, BookDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetByIsbnQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BookDto> Handle(GetByIsbnQuery request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.Books.GetByIsbnAsync(request.ISBN, cancellationToken);
            if(book == null)
            {
               throw new KeyNotFoundException("not found");
            }
            return _mapper.Map<BookDto>(book);
        }
    }
}
