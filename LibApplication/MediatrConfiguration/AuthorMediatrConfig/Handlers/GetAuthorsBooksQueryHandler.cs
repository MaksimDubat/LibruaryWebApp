using AutoMapper;
using LibruaryAPI.Application.Contcracts.DTOs;
using LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Quaries;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Domain.Interfaces;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик запроса на получение книг автора.
    /// </summary>
    public class GetAuthorsBooksQueryHandler : IRequestHandler<GetAuthorsBooksQuery, IEnumerable<BookDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAuthorsBooksQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BookDto>> Handle(GetAuthorsBooksQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Authors.GetBooksByAuthorNameAsync(request.FirstName, request.LastName, cancellationToken);
            return _mapper.Map<IEnumerable<BookDto>>(result);
        }
    }
}
