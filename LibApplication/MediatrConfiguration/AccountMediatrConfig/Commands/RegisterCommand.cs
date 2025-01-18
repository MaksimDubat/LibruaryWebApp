using LibruaryAPI.Application.Contcracts.Models;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AccountMediatrConfig.Commands
{
    /// <summary>
    /// Модель команды регистрации пользователя.
    /// </summary>
    public class RegisterCommand : IRequest<RegistrationModel>
    {
        /// <summary>
        /// Модель регистрации.
        /// </summary>
        public RegistrationModel Model { get; set; }

        public RegisterCommand(RegistrationModel model)
        {
            Model = model;
        }
    }
}
