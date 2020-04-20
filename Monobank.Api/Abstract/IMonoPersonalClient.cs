using Sentinelab.Monobank.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sentinelab.Monobank.Api.Abstract
{
    public interface IMonoPersonalClient
    {
        /// <summary>
        /// Отримання інформації про клієнта та переліку його рахунків. Обмеження на використання функції не частіше ніж 1 раз у 60 секунд.
        /// </summary>
        /// <returns>Інформація про клієнта</returns>
        Task<UserInfo> GetUserInfo();

        /// <summary>
        /// Отримання виписки по вказаному рахунку за час від {from} до {to} часу в секундах в форматі Unix time.
        /// Максимальний час за який можливо отримувати виписку 31 доба + 1 година (2682000 секунд).
        /// Обмеження на використання функції не частіше ніж 1 раз у 60 секунд.
        /// </summary>
        /// <param name="accountId">Ідентифікатор рахунку з переліку Statement list або 0 - дефолтний рахунок.</param>
        /// <param name="from">Початок часу виписки. Наприклад 1546304461</param>
        /// <param name="to">Останній час виписки (якщо відсутній, буде використовуватись поточний час). Наприклад 1546306461</param>
        /// <returns>Виписка</returns>
        Task<IEnumerable<StatementItem>> GetStatement(string accountId, long from, long? to = null);

        /// <summary>
        /// Отримання виписки по дефолтному рахунку за час від {from} до {to} часу в секундах в форматі Unix time.
        /// Максимальний час за який можливо отримувати виписку 31 доба + 1 година (2682000 секунд).
        /// Обмеження на використання функції не частіше ніж 1 раз у 60 секунд.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns>Виписка</returns>
        Task<IEnumerable<StatementItem>> GetStatement(long from, long? to = null);

        /// <summary>
        /// Отримання виписки по вказаному рахунку за час від {from} до {to}.
        /// Максимальний час за який можливо отримувати виписку 31 доба + 1 година.
        /// Обмеження на використання функції не частіше ніж 1 раз у 60 секунд.
        /// </summary>
        /// <param name="accountId">Ідентифікатор рахунку з переліку Statement list або 0 - дефолтний рахунок.</param>
        /// <param name="from">Початок часу виписки. Наприклад 1546304461</param>
        /// <param name="to">Останній час виписки (якщо відсутній, буде використовуватись поточний час). Наприклад 1546306461</param>
        /// <returns>Виписка</returns>
        Task<IEnumerable<StatementItem>> GetStatement(string accountId, DateTime from, DateTime? to = null);

        /// <summary>
        /// Отримання виписки по дефолтному рахунку за час від {from} до {to}.
        /// Максимальний час за який можливо отримувати виписку 31 доба + 1 година.
        /// Обмеження на використання функції не частіше ніж 1 раз у 60 секунд.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns>Виписка</returns>
        Task<IEnumerable<StatementItem>> GetStatement(DateTime from, DateTime? to = null);

        /// <summary>
        /// Встановлення URL користувача, на який буде сформовано POST запит у форматі {type:"StatementItem", data:{account:"...", statementItem:{#StatementItem}}}. 
        /// Якщо сервіс користувача не відповість протягом 5с на команду, сервіс повторить спробу ще через 60 та 600 секунд. 
        /// Якщо на третью спробу відповідь отримана не буде, функція буде вимкнута.
        /// </summary>
        /// <param name="webHookUrl"></param>
        /// <returns></returns>
        Task SetWebHook(string webHookUrl);
    }
}
