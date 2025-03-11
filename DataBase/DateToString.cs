using System;
using System.Globalization;

namespace DataBase
{
    class DateToString
    {
        DateTime date = DateTime.Now;
        public string GetDateInWords()
        {
            return ConvertDateToWords(date);
        }

        private string ConvertDateToWords(DateTime date)
        {
            // Місяці українською
            string[] months = {
            "січня", "лютого", "березня", "квітня", "травня", "червня",
            "липня", "серпня", "вересня", "жовтня", "листопада", "грудня"
            };

            // Одиниці чисел
            string[] ones = { "", "один", "два", "три", "чотири", "п'ять", "шість", "сім", "вісім", "дев'ять" };

            // Десятки чисел
            string[] tens = { "", "десять", "двадцять", "тридцять", "сорок", "п'ятдесят", "шістдесят", "сімдесят", "вісімдесят", "дев'яносто" };

            // Сотні чисел
            string[] hundreds = { "", "сто", "двісті", "триста", "чотириста", "п'ятсот", "шістсот", "сімсот", "вісімсот", "дев'ятсот" };

            // Тисячі
            string[] thousands = { "", "тисяча", "дві тисячі", "три тисячі", "чотири тисячі", "п'ять тисяч", "шість тисяч", "сім тисяч", "вісім тисяч", "дев'ять тисяч" };

            // Рік, обробка сотень, десятків і одиниць
            int year = date.Year;
            string yearWords = ConvertNumberToWords(year, ones, tens, hundreds, thousands);

            // День
            int day = date.Day;
            string dayWords = ConvertDayToWords(day, ones, tens);

            // Місяць
            string monthWords = months[date.Month - 1];

            // Формуємо кінцевий результат
            return $"{dayWords} {monthWords} {yearWords} року";
        }

        // Метод для перетворення дня в текст
        private string ConvertDayToWords(int day, string[] ones, string[] tens)
        {
            if (day < 10)
                return ones[day];
            else if (day < 20)
                return ones[day]; // Для чисел від 10 до 19 просто повертаємо число в прописному варіанті
            else
            {
                int ten = day / 10;
                int one = day % 10;
                return $"{tens[ten]} {ones[one]}";
            }
        }

        // Метод для перетворення числа в текст
        static string ConvertNumberToWords(int number, string[] ones, string[] tens, string[] hundreds, string[] thousands)
        {
            string words = "";

            int thousand = number / 1000;
            number %= 1000;

            int hundred = number / 100;
            number %= 100;

            int ten = number / 10;
            int one = number % 10;

            if (thousand > 0)
                words += thousands[thousand] + " ";

            if (hundred > 0)
                words += hundreds[hundred] + " ";

            if (ten > 1)
                words += tens[ten] + " ";

            if (one > 0)
                words += ones[one];

            return words.Trim();
        }
    }
}
