# Monobank.Api

## How to use:
### PublicClient:
```
var client = new MonobankApi();
var currencies = await client.PublicClient.GetCurrenciesAsync();
```

### PersonalClient:
```
var client = new MonobankApi("MONOBANK_TOKEN");
await client.PersonalClient.SetWebHook(webHookUrl);
var userInfo = await client.PersonalClient.GetUserInfo();
var statement = await client.PersonalClient.GetStatement(DateTime.UtcNow.AddDays(-2));
```
