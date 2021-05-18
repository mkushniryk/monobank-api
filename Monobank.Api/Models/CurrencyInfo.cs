namespace Monobank.Api.Client.Models
{
    public class CurrencyInfo
    {
        /// <summary>
        /// Account currency code according to ISO 4217
        /// </summary>
        public int CurrencyCodeA { get; set; }

        /// <summary>
        /// Account currency code according to ISO 4217
        /// </summary>
        public int CurrencyCodeB { get; set; }

        /// <summary>
        /// Course time in seconds in Unix time format
        /// </summary>
        public long Date { get; set; }

        /// <summary>
        /// Sale rate
        /// </summary>
        public float RateSell { get; set; }

        /// <summary>
        /// Buy rate
        /// </summary>
        public float RateBuy { get; set; }

        /// <summary>
        /// Cross Rate
        /// </summary>
        public float RateCross { get; set; }
    }
}