using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AccountMediatrConfig.Commands
{
    /// <summary>
    /// Модель комнады для выхода пользователя. 
    /// </summary>
    public class LogoutCommand : IRequest<Unit>
    {
    }
}
