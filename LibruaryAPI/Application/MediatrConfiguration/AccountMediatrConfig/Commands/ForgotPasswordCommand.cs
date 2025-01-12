using LibruaryAPI.Infrastructure.Models;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AccountMediatrConfig.Commands
{
    /// <summary>
    /// Модель команды сброса пароля.
    /// </summary>
    public class ForgotPasswordCommand : IRequest<bool>
    {
        /// <summary>
        /// Модель сброса пароля.
        /// </summary>
        public PasswordResetModel Model { get; set; }
        public ForgotPasswordCommand(PasswordResetModel model)
        {
            Model = model;
        }
    }
}
