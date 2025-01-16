namespace LibruaryAPI.Domain.Common
{
    /// <summary>
    /// Генерация ISBN.
    /// </summary>
    public static class ISBNGenerator
    {
        public static string GenerateISBN()
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
        public static int CalculateCheckDigit(string isbnWithoutCheckDigit)
        {
            int sum = 0;
            for (int i = 0; i < isbnWithoutCheckDigit.Length; i++)
            {
                int digit = int.Parse(isbnWithoutCheckDigit[i].ToString());
                sum += i % 2 == 0 ? digit : digit * 3;
            }

            int remainder = sum % 10;
            return remainder == 0 ? 0 : 10 - remainder;
        }
    }
}
