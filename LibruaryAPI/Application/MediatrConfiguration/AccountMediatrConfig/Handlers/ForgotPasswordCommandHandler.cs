using LibruaryAPI.Application.MediatrConfiguration.AccountMediatrConfig.Commands;
using LibruaryAPI.Domain.Interfaces;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AccountMediatrConfig.Handlers
{

    /// <summary>
    /// Обработчик для сброса пароля пользователя.
    /// </summary>
    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, bool>
    {
        private readonly ILibAuthenticationService _authenticationService;
        private readonly IUnitOfWork _unitOfWork;
        public ForgotPasswordCommandHandler(ILibAuthenticationService authenticationService, IUnitOfWork unitOfWork)
        {
            _authenticationService = authenticationService;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var resetModel = request.Model;
            var result = await _authenticationService.ResetPasswordAsync(
                resetModel.Email,
                resetModel.Token,
                resetModel.NewPassword,
                cancellationToken);
            if (!result)
            {
                return false;
            }
            await _unitOfWork.CompleteAsync(cancellationToken);
            return true;
        }
    }
}
