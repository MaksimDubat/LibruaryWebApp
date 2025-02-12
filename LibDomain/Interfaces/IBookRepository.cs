﻿using LibruaryAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace LibruaryAPI.Domain.Interfaces
{
    /// <summary>
    /// Интерфейс по работе с книгами.
    /// </summary>
    public interface IBookRepository : IBaseRepository<Book>
    {
        /// <summary>
        /// Получение книги по ISBN.
        /// </summary>
        /// <param name="isbn"></param>
        /// <param name="cancellation"></param>
        Task<Book> GetByIsbnAsync(string isbn, CancellationToken cancellation);
        /// <summary>
        /// Выдача книги.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        /// <param name="cancellation"></param>
        Task<string> IssueAsync(int userId, int bookId, CancellationToken cancellation);
        /// <summary>
        /// Подтверждение выдачи.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        /// <param name="cancellation"></param>
        Task<string> ConfirmIssuanceAsync(int userId, int bookId, CancellationToken cancellation);
    }

}
