using LibruaryAPI.Application.MediatrConfiguration.AccountMediatrConfig.Commands;
using LibruaryAPI.Domain.Interfaces;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AccountMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик команды для взода пользователя.
    /// </summary>
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly ILibAuthenticationService _authenticationService;

        public LoginCommandHandler(ILibAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var token = await _authenticationService.SignInAsync(request.Model.Email, request.Model.Email, cancellationToken);
                return token;
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new UnauthorizedAccessException("invalid", ex);
            }
        }
    }
}
