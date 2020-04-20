namespace Sentinelab.Monobank.Api.Models
{
    /// <summary>
    /// Транзакція
    /// </summary>
    public class StatementItem
    {
        /// <summary>
        /// Унікальний id транзакції
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Час транзакції в секундах в форматі Unix time
        /// </summary>
        public long Time { get; set; }

        /// <summary>
        /// Опис транзакцій
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Код типу транзакції (Merchant Category Code), відповідно ISO 18245
        /// </summary>
        public int Mcc { get; set; }

        /// <summary>
        /// Статус блокування суми
        /// </summary>
        public bool Hold { get; set; }

        /// <summary>
        /// Сума у валюті рахунку в мінімальних одиницях валюти (копійках, центах)
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
    }
}
