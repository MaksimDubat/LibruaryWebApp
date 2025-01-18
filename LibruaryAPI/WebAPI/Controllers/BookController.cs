using LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Commands;
using LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Queries;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Infrastructure.HttpExtension;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibruaryAPI.WebAPI.Controllers
{
    /// <summary>
    /// Контроллер по работе с книгами.
    /// </summary>
    [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Получение всех книг.
        /// </summary>
        /// <param name="cancellation"></param>
        [Authorize(Policy = ("UserOrAdminPolicy"))]
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks(CancellationToken cancellation)
        {
            var books = await _mediator.Send(new GetAllQuery(), cancellation);
            return Ok(books);
        }
        /// <summary>
        /// Получение книги по идентификатору.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellation"></param>
        [Authorize(Policy = ("AdminPolicy"))]
        [HttpGet("get-book-by-id/{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id, CancellationToken cancellation)
        {
            var query = new GetByIdQuery(id);
            var book = await _mediator.Send(query, cancellation);
            return Ok(book);
        }
        /// <summary>
        /// Получение книги по ISBN.
        /// </summary>
        /// <param name="isbn"></param>
        /// <param name="cancellation"></param>
        [Authorize(Policy = ("UserOrAdminPolicy"))]
        [HttpGet("get-by-ISBN{isbn}")]
        public async Task<ActionResult<Book>> GetBookByISBN(string isbn, CancellationToken cancellation)
        {
            var query = new GetByIsbnQuery(isbn);
            var book = await _mediator.Send(query, cancellation);
            return Ok(book);
        }
        /// <summary>
        /// Получение книг с пагинацией.
        /// </summary>
        /// <param name="pagedNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="cancellation"></param>
        [Authorize(Policy = ("UserOrAdminPolicy"))]
        [HttpGet("paged-books")]
        public async Task<IActionResult> GetBooksPaged(CancellationToken cancellation, [FromQuery] int pagedNumber = 1, [FromQuery] int pageSize = 10)
        {
            var query = new GetBooksPagedQuery(pagedNumber, pageSize);
            var book = await _mediator.Send(query, cancellation);
            return Ok(book);
        }
        /// <summary>
        /// Добавление книги.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellation"></param>
        [Authorize(Policy = ("AdminPolicy"))]
        [HttpPost("Add-book")]
        public async Task<ActionResult<Book>> AddBook([FromBody] AddBookCommand command, CancellationToken cancellation)
        {
            var result = await _mediator.Send(command, cancellation);
            return Ok(result);
        }
        /// <summary>
        /// Обновление книги.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <param name="cancellation"></param>
        [Authorize(Policy = ("AdminPolicy"))]
        [HttpPost("Update-book/{id}")]
        public async Task<ActionResult<Book>> UpdateBook(int id, [FromBody] UpdateBookCommand command, CancellationToken cancellation)
        {
            var updateBook = await _mediator.Send(command, cancellation);
            return Ok(updateBook);
        }
        /// <summary>
        /// Удаление книги.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellation"></param>
        [Authorize(Policy = ("AdminPolicy"))]
        [HttpPost("Delete-book/{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id, CancellationToken cancellation)
        {
            var command = new DeleteBookCommand(id);
            var result = await _mediator.Send(command, cancellation);
            return Ok("deleted");
        }
        /// <summary>
        /// Подтверждение выдачи.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellation"></param>
        [Authorize(Policy = ("AdminPolicy"))]
        [HttpPost("Confirm-Issueance")]
        public async Task<IActionResult> ConfirmIssuance([FromBody] ConfirmIssuanceCommand command, CancellationToken cancellation)
        {
            var result = await _mediator.Send(command, cancellation);
            return Ok("Isseued");
        }
        /// <summary>
        /// Запрос на выдачу книги.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellation"></param>
        [Authorize(Policy = "UserOrAdminPolicy")]
        [HttpPost("Issue")]
        public async Task<IActionResult> IssueBook([FromBody] IssueCommand command, CancellationToken cancellation)
        {
            var result = await _mediator.Send(command, cancellation);
            return Ok();
        }
        /// <summary>
        /// Загрузка изображения.
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="file"></param>
        /// <param name="cancellation"></param>
        [Authorize(Policy = "AdminPolicy")]
        [HttpPost("{bookId}/upload-image")]
        public async Task<IActionResult> UploadBookImage(int bookId, [FromForm] IFormFile file, CancellationToken cancellation)
        {
            var command = new UploadImageCommand(bookId, file);
            var book = await _mediator.Send(command, cancellation);
            return Ok();
        }
    }
}
