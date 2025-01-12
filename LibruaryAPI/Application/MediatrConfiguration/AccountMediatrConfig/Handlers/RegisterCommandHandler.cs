using LibruaryAPI.Application.Interfaces;
using LibruaryAPI.Application.MediatrConfiguration.AccountMediatrConfig.Commands;
using LibruaryAPI.Infrastructure.Models;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AccountMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик команды регистрации пользователя.
    /// </summary>
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegistrationModel>
    {
        private readonly ILibAuthenticationService _authenticationService;

        public RegisterCommandHandler(ILibAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        async Task<RegistrationModel> IRequestHandler<RegisterCommand, RegistrationModel>.Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var model = request.Model;
            if (model.Password != model.ConfirmPassword)
            {
                model.Errors = new List<string>();
                return model;
            }
            var result = await _authenticationService.RegisterAsync(
               request.Model.Email,
               request.Model.Name,
               request.Model.Password,
               cancellationToken);

            if (!result.Succeeded)
            {
                model.Errors = result.Errors.Select(e => e.Description).ToList();
                return model;
            }
            model.Errors = null;
            return model;
        }
    }
}

