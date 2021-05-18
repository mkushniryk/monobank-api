using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Monobank.Api.Client.Models;
using RestSharp;

namespace Monobank.Api.Client.Abstractions
{
    public interface IMonobankClient
    {
        /// <summary>
        /// Obtaining information about the client and his list of accounts. Restrictions on the use of the function no more than once every 60 seconds.
        /// </summary>
        /// <returns>Client information</returns>
        Task<ClientInfo> GetClientInfoAsync();

        /// <summary>
        /// Receive a statement on the specified account for the time from {from} to {to} time in seconds in Unix time format.
        /// The maximum time for which it is possible to receive a statement 31 days + 1 hour (2682000 seconds).
        /// Restrictions on the use of the function no more than once every 60 seconds.
        /// </summary>
        /// <param name="accountId">Account Id from the Statement list or 0 - default account.</param>
        /// <param name="from">Start of statement time. For example 1546304461</param>
        /// <param name="to">Last statement time (if not set, the current time will be used). For example 1546306461</param>
        /// <returns>Statements</returns>
        Task<IEnumerable<StatementItem>> GetStatementAsync(string accountId, long from, long? to = null);

        /// <summary>
        /// Receive a default account statement for the time from {from} to {to} time in seconds in Unix time format.
        /// The maximum time for which it is possible to receive a statement 31 days + 1 hour (2682000 seconds).
        /// Restrictions on the use of the function no more than once every 60 seconds.
        /// </summary>
        /// <param name="from">Start of statement time. For example 1546304461</param>
        /// <param name="to">Last statement time (if not set, the current time will be used). For example 1546306461</param>
        /// <returns>Statements</returns>
        Task<IEnumerable<StatementItem>> GetStatementAsync(long from, long? to = null);

        /// <summary>
        /// Receive a statement on the specified account for the time from {from} to {to}.
        /// The maximum time for which it is possible to receive a statement is 31 days + 1 hour.
        /// Restrictions on the use of the function no more than once every 60 seconds.
        /// </summary>
        /// <param name="accountId">Account Id from the Statement list or 0 - default account.</param>
        /// <param name="from">Start of statement time.</param>
        /// <param name="to">Last statement time (if not set, the current time will be used).</param>
        /// <returns>Statements</returns>
        Task<IEnumerable<StatementItem>> GetStatementAsync(string accountId, DateTime from, DateTime? to = null);

        /// <summary>
        /// Receive a default account statement for the time from {from} to {to}.
        /// The maximum time for which it is possible to receive a statement is 31 days + 1 hour.
        /// Limit the use of functions at least once every 60 seconds.
        /// </summary>
        /// <param name="from">Start of statement time.</param>
        /// <param name="to">Last statement time (if not set, the current time will be used).</param>
        /// <returns>Statements</returns>
        Task<IEnumerable<StatementItem>> GetStatementAsync(DateTime from, DateTime? to = null);

        /// <summary>
        /// Set the URL of the user to whom the POST request will be generated in the format {type: "StatementItem", data: {account: "...", statementItem: {# StatementItem}}}. 
        /// If the user service does not respond to the command within 5 seconds, the service will try again in 60 and 600 seconds.
        /// If no response is received on the third attempt, the function will be disabled.
        /// </summary>
        /// <param name="webHookUrl">Webhook url</param>
        /// <returns>Rest response</returns>
        Task<IRestResponse> SetWebHookAsync(string webHookUrl);
    }
}