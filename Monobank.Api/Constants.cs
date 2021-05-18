namespace Monobank.Api.Client
{
    internal class Constants
    {
        internal const string ApiGatewayPath = "https://api.monobank.ua";
        internal const string DefaultUserAccount = "0";

        internal const string GetCurrencyResource = "/bank/currency";
        internal const string GetClientInfoResource = "/personal/client-info";
        internal const string GetStatementResource = "/personal/statement";
        internal const string SetWebHook = "/personal/webhook";

        internal const string AuthTokenKey = "X-Token";
    }
}