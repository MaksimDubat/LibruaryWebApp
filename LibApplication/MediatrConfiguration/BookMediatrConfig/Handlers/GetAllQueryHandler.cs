using AutoMapper;
using LibruaryAPI.Application.Contcracts.DTOs;
using LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Queries;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Domain.Interfaces;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик запроса получения всех книг.
    /// </summary>
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<BookDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BookDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Books.GetAllAsync(cancellationToken).ConfigureAwait(false);
            if(result == null)
            {
                throw new ArgumentNullException();
            }
            return _mapper.Map<IEnumerable<BookDto>>(result); 
        }
    }
}
