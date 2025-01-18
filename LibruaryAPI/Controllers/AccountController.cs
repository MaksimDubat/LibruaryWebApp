using LibruaryAPI.Application.Contcracts.Models;
using LibruaryAPI.Application.MediatrConfiguration.AccountMediatrConfig.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibruaryAPI.Controllers
{
    /// <summary>
    /// Контроллер для работы с аккаунтом.
    /// </summary>
    [ApiController]
    [Route("api/auth")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Осуществление входа пользователя.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellation"></param>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model, CancellationToken cancellation)
        {
            var command = new LoginCommand(model);
            var token = await _mediator.Send(command, cancellation);
            return Ok();
        }
        /// <summary>
        /// Осуществление выхода пользователя.
        /// </summary>
        /// <param name="cancellation"></param>
        [Authorize(Policy = "UserOrAdminPolicy")]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout(CancellationToken cancellation)
        {
            await _mediator.Send(new LogoutCommand(), cancellation);
            return Ok();
        }
        /// <summary>
        /// Осуществление регистрации пользователя.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellation"></param>
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationModel model, CancellationToken cancellation)
        {
            var command = new RegisterCommand(model);
            var result = await _mediator.Send(command, cancellation);
            return Ok();
        }
        /// <summary>
        /// Осуществление функционала для восстановления пароля.
        /// </summary>
        /// <param name="model"></param>
        [Authorize(Policy = "UserOrAdminPolicy")]
        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] PasswordResetModel model, CancellationToken cancellation)
        {
            var command = new ForgotPasswordCommand(model);
            var result = await _mediator.Send(command, cancellation);
            return Ok();
        }

    }
}
