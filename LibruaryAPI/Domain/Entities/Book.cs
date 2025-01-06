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
        public required string ISBN { get; set; } = GenerateISBN();
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
        public string? Image { get; set; }
        /// <summary>
        /// КОличество экземпляров.
        /// </summary>
        public int Amount { get; set; }
        private static string GenerateISBN()
        {
            var random = new Random();
            var prfix = "978";
            var regGroup = random.Next(100, 999).ToString();
            var registrant = random.Next(1000, 9999).ToString();
            var editor = random.Next(1000, 9999).ToString();
            var isbnWithOutChek = prfix + regGroup + registrant + editor;
            var chekDigit = CalculateCheckDigit(isbnWithOutChek);
            return isbnWithOutChek + chekDigit;
        }
        private static int CalculateCheckDigit(string isbnWithoutCheckDigit)
        {
            int sum = 0;
            for (int i = 0; i < isbnWithoutCheckDigit.Length; i++)
            {
                int digit = int.Parse(isbnWithoutCheckDigit[i].ToString());
                sum += (i % 2 == 0) ? digit : digit * 3; 
            }

            int remainder = sum % 10;
            return (remainder == 0) ? 0 : 10 - remainder;
        }
    }
}
}
