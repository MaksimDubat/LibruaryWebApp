using AutoMapper;
using LibruaryAPI.Application.Contcracts.DTOs;
using LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Queries;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Domain.Interfaces;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик запроса на пагинацию.
    /// </summary>
    public class GetBooksPagedQueryHandler : IRequestHandler<GetBooksPagedQuery, IEnumerable<BookDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public GetBooksPagedQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetBooksPagedQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Books.GetPagedAsync(request.PageNumber, request.PageSize, cancellationToken);
            if(result == null)
            {
                throw new ArgumentNullException();
            }
            return _mapper.Map<IEnumerable<BookDto>>(result);
        }
    }
}
