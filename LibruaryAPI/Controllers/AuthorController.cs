﻿using LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Commands;
using LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Quaries;
using LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Commands;
using LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Queries;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Infrastructure.HttpExtension;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibruaryAPI.Controllers
{
    /// <summary>
    /// Контроллер по работе с авторами.
    /// </summary>
    [ApiController]
    [Route("api/authors-managment")]
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
        [Authorize(Policy = "UserOrAdminPolicy")]
        [HttpGet("authors")]
        public async Task<ActionResult<IEnumerable<Author>>> GetAllAuthros(CancellationToken cancellation)
        {
            var authors = await _mediator.Send(new GetAllAuthorsQuery(), cancellation);
            return Ok(authors);
        }
        /// <summary>
        /// Получение автора по идентификатору.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellation"></param>
        [Authorize(Policy = "AdminPolicy")]
        [HttpGet("author/{id}")]
        public async Task<ActionResult<Author>> GetAuthorById(int id, CancellationToken cancellation)
        {
            var query = new GetAuthorByIdQuery(id);
            var author = await _mediator.Send(query, cancellation);
            return Ok(author);
        }
        /// <summary>
        /// Получение книг автора.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="cancellation"></param>
        [Authorize(Policy = "UserOrAdminPolicy")]
        [HttpGet("author-books")]
        public async Task<IActionResult> GetAllAuthorsBooks(string firstName, string lastName, CancellationToken cancellation)
        {
            var query = new GetAuthorsBooksQuery(firstName, lastName);
            var books = await _mediator.Send(query, cancellation);
            return Ok(books);
        }
        /// <summary>
        /// Пагинация авторов.
        /// </summary>
        /// <param name="cancellation"></param>
        /// <param name="pagedNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Authorize(Policy = "UserOrAdminPolicy")]
        [HttpGet("paged")]
        public async Task<IActionResult> GetAuthorsPaged(CancellationToken cancellation, [FromQuery] int pagedNumber = 1, [FromQuery] int pageSize = 10)
        {
            var query = new GetAuthorsPagedQuery(pagedNumber, pageSize);
            var authors = await _mediator.Send(query, cancellation);
            return Ok(authors);
        }
        /// <summary>
        /// Добавление автора.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellation"></param>
        [Authorize(Policy = "AdminPolicy")]
        [HttpPost]
        public async Task<ActionResult<Author>> AddAuthor([FromBody] AddAuthorCommand command, CancellationToken cancellation)
        {
            var result = await _mediator.Send(command, cancellation);
            return Ok(result);
        }
        /// <summary>
        /// Обновление автора.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <param name="cancellation"></param>
        [Authorize(Policy = "AdminPolicy")]
        [HttpPut("{id}")]
        public async Task<ActionResult<Author>> UpdateAuthor(int id, [FromBody] UpdateAuthorCommand command, CancellationToken cancellation)
        {
            var updateAuthor = await _mediator.Send(command, cancellation);
            return Ok(updateAuthor);
        }
        /// <summary>
        /// Удаление автора.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellation"></param>
        [Authorize(Policy = "AdminPolicy")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Author>> DeleteAuthor(int id, CancellationToken cancellation)
        {
            var command = new DeleteAuthorCommand(id);
            var result = await _mediator.Send(command, cancellation);
            return Ok("deleted");
        }
    }
}
