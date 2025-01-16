using LibruaryAPI.Application.MediatrConfiguration.AccountMediatrConfig.Commands;
using LibruaryAPI.Domain.Interfaces;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AccountMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик запроса выхода пользователя.
    /// </summary>
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand, Unit>
    {
        private readonly ILibAuthenticationService _authenticationService;
        public LogoutCommandHandler(ILibAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            await _authenticationService.SignOutAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
