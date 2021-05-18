namespace Monobank.Api.Client.Models
{
    /// <summary>
    /// Transaction
    /// </summary>
    public class StatementItem
    {
        /// <summary>
        /// Transaction Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Transaction time in seconds in Unix time format
        /// </summary>
        public long Time { get; set; }

        /// <summary>
        /// Transaction description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Transaction type code (Merchant Category Code), according to ISO 18245
        /// </summary>
        public int Mcc { get; set; }

        /// <summary>
        /// Amount hold status
        /// </summary>
        public bool Hold { get; set; }

        /// <summary>
        /// Amount in the currency of the account in the minimum currency units
        /// </summary>
        public long Amount { get; set; }

        /// <summary>
        /// Сума у валюті транзакції в мінімальних одиницях валюти (копійках, центах)
        /// </summary>
        public long OperationAmount { get; set; }

        /// <summary>
        /// Код валюти рахунку відповідно ISO 4217
        /// </summary>
        public int CurrencyCode { get; set; }

        /// <summary>
        /// Розмір комісії в мінімальних одиницях валюти (копійках, центах)
        /// </summary>
        public long CommissionRate { get; set; }

        /// <summary>
        /// Розмір кешбеку в мінімальних одиницях валюти (копійках, центах)
        /// </summary>
        public long CashbackAmount { get; set; }

        /// <summary>
        /// Баланс рахунку в мінімальних одиницях валюти (копійках, центах)
        /// </summary>
        public long Balance { get; set; }

        /// <summary>
        /// User-entered comment on the transfer. If not specified, the field will be missing
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Receipt number for https://check.gov.ua
        /// </summary>
        public string ReceiptId { get; set; }

        /// <summary>
        /// UDRPOU of the counterparty, present only for the elements of the private individual
        /// </summary>
        public string CounterEdrpou { get; set; }

        /// <summary>
        /// Counterparty IBAN, present only for the elements of the private individual
        /// </summary>
        public string CounterIban { get; set; }
    }
}