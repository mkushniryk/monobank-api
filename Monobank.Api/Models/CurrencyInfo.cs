namespace Sentinelab.Monobank.Api.Models
{
    public class CurrencyInfo
    {
        /// <summary>
        /// Код валюти рахунку відповідно ISO 4217
        /// </summary>
        public int CurrencyCodeA { get; set; }

        /// <summary>
        /// Код валюти рахунку відповідно ISO 4217
        /// </summary>
        public int CurrencyCodeB { get; set; }

        /// <summary>
        /// Час курсу в секундах в форматі Unix time
        /// </summary>
        public long Date { get; set; }

        /// <summary>
        /// Курс продажу
        /// </summary>
        public float RateSell { get; set; }

        /// <summary>
        /// Курс покупки
        /// </summary>
        public float RateBuy { get; set; }

        /// <summary>
        /// Крос-курс
        /// </summary>
        public float RateCross { get; set; }
    }
}
