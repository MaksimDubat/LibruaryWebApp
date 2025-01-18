using AutoMapper;
using LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Commands;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Domain.Interfaces;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик команды добавления автора.
    /// </summary>
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AddAuthorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<string> Handle(AddAuthorCommand request, CancellationToken cancellation)
        {
            var exist = await _unitOfWork.Authors.AnyAsync(
                x => x.FirstName == request.Author.FirstName && 
                x.LastName == request.Author.LastName &&
                x.Country == request.Author.Country &&
                x.BirthDate == request.Author.BirthDate,
                cancellation);  
            if (exist)
            {
                return "Already exist";
            }
            var author = _mapper.Map<Author>(request.Author);
            await _unitOfWork.Authors.AddAsync(author, cancellation);
            await _unitOfWork.CompleteAsync(cancellation);
            return "ok";
        }
    }
}
