using AutoMapper;
using LibruaryAPI.Application.Contcracts.DTOs;
using LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Queries;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Domain.Interfaces;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик запроса на получение книги по идентификатору.
    /// </summary>
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, BookDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BookDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.Books.GetAsync(request.Id, cancellationToken);
            if (book == null)
            {
                throw new ArgumentNullException("invalid");
            }
            return _mapper.Map<BookDto>(book);
        }
    }
}
