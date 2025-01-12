using LibruaryAPI.Infrastructure.Models;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AccountMediatrConfig.Commands
{
    /// <summary>
    /// Модель команды для осуществления входа пользователя.
    /// </summary>
    public class LoginCommand : IRequest<string>
    {
        /// <summary>
        /// Модель входа.
        /// </summary>
        public LoginModel Model { get; set; }

        public LoginCommand(LoginModel model)
        {
            Model = model;
        }
    }
}
