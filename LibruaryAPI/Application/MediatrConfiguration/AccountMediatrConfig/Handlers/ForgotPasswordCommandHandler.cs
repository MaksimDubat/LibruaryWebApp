using LibruaryAPI.Application.Interfaces;
using LibruaryAPI.Application.MediatrConfiguration.AccountMediatrConfig.Commands;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AccountMediatrConfig.Handlers
{

    /// <summary>
    /// Обработчик для сброса пароля пользователя.
    /// </summary>
    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, bool>
    {
        private readonly ILibAuthenticationService _authenticationService;
        public ForgotPasswordCommandHandler(ILibAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public async Task<bool> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var resetModel = request.Model;
            return await _authenticationService.ResetPasswordAsync(
                resetModel.Email,
                resetModel.Token,
                resetModel.NewPassword,
                cancellationToken);
        }
    }
}
