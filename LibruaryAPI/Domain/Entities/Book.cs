using LibruaryAPI.Application.Common;
using System.CodeDom.Compiler;

namespace LibruaryAPI.Domain.Entities
{
    /// <summary>
    /// Сущность книги.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Идентификатор книги.
        /// </summary>
        public int BookId { get; set; }
        /// <summary>
        /// Уникальный код, генерируемый для книги.
        /// </summary>
        public required string ISBN { get; set; } = ISBNGenerator.GenerateISBN();
        /// <summary>
        /// Название книги.
        /// </summary>
        public required string Title { get; set; }
        /// <summary>
        /// Описание книги.
        /// </summary>
        public required string Description { get; set; }
        /// <summary>
        /// Когда взяли книгу.
        /// </summary>
        public DateTime TakenAt { get; set; }
        /// <summary>
        /// Идентификатор автора.
        /// </summary>
        public int AuthorId { get; set; }
        /// <summary>
        /// Автор.
        /// </summary>
        public required Author Author { get; set; } 
        /// <summary>
        /// Статус доступности.
        /// </summary>
        public bool IsAvaiable { get; set; } = true;
        /// <summary>
        /// Изображение книги.
        /// </summary>
        public required string Image { get; set; }
        /// <summary>
        /// КОличество экземпляров.
        /// </summary>
        public int Amount { get; set; }
        
    }
}

