﻿using LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Commands;
using LibruaryAPI.Domain.Interfaces;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик команды выдачи книги.
    /// </summary>
    public class IssueCommandHandler : IRequestHandler<IssueCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        public IssueCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<string> Handle(IssueCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Books.IssueAsync(request.UserId, request.BookId, cancellationToken);
            if (result == null)
            {
                throw new ArgumentNullException();
            }
            await _unitOfWork.CompleteAsync(cancellationToken);
            return "issued";
        }
    }
}
