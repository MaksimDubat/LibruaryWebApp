﻿using LibruaryAPI.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibruaryAPI.Infrastructure.UnitOfWork
{
    /// <summary>
    /// Интерфейс паттерна UnityOfWork
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Репозиторий по работе с книгами.
        /// </summary>
        IBookRepository Books { get; }
        /// <summary>
        /// Репозиторий по работе с авторами.
        /// </summary>
        IAuthorRepository Authors { get; }
        /// <summary>
        /// Базовый репозиторий.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        IBaseRepository<T> GetRepository<T>() where T : class;
        /// <summary>
        /// Заврешение операции.
        /// </summary>
        /// <param name="cancellation"></param>
        Task<int> CompleteAsync(CancellationToken cancellation);
    }
}
