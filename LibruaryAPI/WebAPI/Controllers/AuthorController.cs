using LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Commands;
using LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Quaries;
using LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Commands;
using LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Queries;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Infrastructure.HttpExtension;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibruaryAPI.WebAPI.Controllers
{
    /// <summary>
    /// Контроллер по работе с авторами.
    /// </summary>
    [ApiController]
    [Route("api/authors")]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Получение всех авторов.
        /// </summary>
        /// <param name="cancellation"></param>
        [Authorize(Policy = ("UserOrAdminPolicy"))]
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Author>>> GetAllAuthros(CancellationToken cancellation)
        {
            var user = HttpContext.GetUserId();
            if(user == null)
            {
                return Unauthorized();
            }
            var authors = await _mediator.Send(new GetAllAuthorsQuery(), cancellation);
            if (authors == null)
            {
                return NotFound();
            }
            return Ok(authors);
        }
        /// <summary>
        /// Получение автора по идентификатору.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellation"></param>
        [Authorize(Policy = ("AdminPolicy"))]
        [HttpGet("get-author-by-id/{id}")]
        public async Task<ActionResult<Author>> GetAuthorById(int id, CancellationToken cancellation)
        {
            var user = HttpContext.GetUserId();
            if (user == null)
            {
                return Unauthorized();
            }
            var query = new GetAuthorByIdQuery(id);
            var author = await _mediator.Send(query, cancellation);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }
        /// <summary>
        /// Получение книг автора.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="cancellation"></param>
        [Authorize(Policy = ("UserOrAdminPolicy"))]
        [HttpGet("all-authors-books")]
        public async Task<IActionResult> GetAllAuthorsBooks(string firstName,  string lastName, CancellationToken cancellation)
        {
            var user = HttpContext.GetUserId();
            if( user == null)
            {
                return Unauthorized();
            }
            if(string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                return BadRequest();
            }
            var query = new GetAuthorsBooksQuery(firstName, lastName);
            var books = await _mediator.Send(query,cancellation);
            if (books == null)
            {
                return BadRequest();
            }
            return Ok(books);
        }
        /// <summary>
        /// Пагинация авторов.
        /// </summary>
        /// <param name="cancellation"></param>
        /// <param name="pagedNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Authorize(Policy = ("UserOrAdminPolicy"))]
        [HttpGet("paged-authors")]
        public async Task<IActionResult> GetAuthorsPaged(CancellationToken cancellation, [FromQuery] int pagedNumber = 1, [FromQuery] int pageSize = 10)
        {
            var user = HttpContext.GetUserId();
            if (user == null)
            {
                return Unauthorized();
            }
            var query = new GetAuthorsPagedQuery(pagedNumber, pageSize);
            var authors = await _mediator.Send(query, cancellation);
            return Ok(authors);
        }
        /// <summary>
        /// Добавление автора.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellation"></param>
        [Authorize(Policy = ("AdminPolicy"))]
        [HttpPost("Add-author")]
        public async Task<ActionResult<Author>> AddAuthor([FromBody] AddAuthorCommand command, CancellationToken cancellation)
        {
            var userId = HttpContext.GetUserId();

            if (userId == null)
            {
                return Unauthorized();
            }
            var result = await _mediator.Send(command, cancellation);
            return Ok(result);
        }
         /// <summary>
         /// Обновление автора.
         /// </summary>
         /// <param name="id"></param>
         /// <param name="command"></param>
         /// <param name="cancellation"></param>
        [Authorize(Policy = ("AdminPolicy"))]
        [HttpPost("Update-author/{id}")]
        public async Task<ActionResult<Author>> UpdateAuthor(int id, [FromBody] UpdateAuthorCommand command, CancellationToken cancellation)
        {
            var userId = HttpContext.GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }
            var updateAuthor = await _mediator.Send(command, cancellation);
            if (id != command.Id)
            {
                return NotFound();
            }
            return Ok(updateAuthor);
        }
        /// <summary>
        /// Удаление автора.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellation"></param>
        [Authorize(Policy = ("AdminPolicy"))]
        [HttpPost("Delete-author/{id}")]
        public async Task<ActionResult<Author>> DeleteAuthor(int id, CancellationToken cancellation)
        {
            var userId = HttpContext.GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }
            var command = new DeleteAuthorCommand(id);
            var result = await _mediator.Send(command, cancellation);
            if (id != command.Id)
            {
                return NotFound();
            }
            return Ok("deleted");
        }
    }
}
