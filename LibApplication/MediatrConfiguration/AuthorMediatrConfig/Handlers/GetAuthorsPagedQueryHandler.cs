using AutoMapper;
using LibruaryAPI.Application.Contcracts.DTOs;
using LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Quaries;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Domain.Interfaces;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик запроса на пагинацию страницы.
    /// </summary>
    public class GetAuthorsPagedQueryHandler : IRequestHandler<GetAuthorsPagedQuery, IEnumerable<AuthorDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private const int PageNumber = 1;
        private const int PageSize = 10;
        public GetAuthorsPagedQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AuthorDto>> Handle(GetAuthorsPagedQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Authors.GetPagedAsync(PageNumber, PageSize, cancellationToken);
            if(result == null)
            {
                throw new ArgumentNullException();
            }
            return _mapper.Map<IEnumerable<AuthorDto>>(result); 
        }
    }
}
