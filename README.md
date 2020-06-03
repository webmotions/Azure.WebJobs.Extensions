# Azure WebJobs Extensions

The Azure WebJobs Extensions is a project that includes various binding extensions for the [Azure WebJobs SDK](https://github.com/Azure/azure-webjobs-sdk).

| Master        | Dev           |
| ------------- |---------------|
| [![Build Status](https://dev.azure.com/webmotions/Azure%20WebJobs%20Extensions/_apis/build/status/webmotions.Azure.WebJobs.Extensions?branchName=master)](https://dev.azure.com/webmotions/Azure%20WebJobs%20Extensions/_build/latest?definitionId=6&branchName=master) | [![Build Status](https://dev.azure.com/webmotions/Azure%20WebJobs%20Extensions/_apis/build/status/webmotions.Azure.WebJobs.Extensions?branchName=master)](https://dev.azure.com/webmotions/Azure%20WebJobs%20Extensions/_build/latest?definitionId=6&branchName=dev) |

## Extensions

### Slack

A [Slack](https://www.slack.com) binding that allows you to easily send rich slack messages after your job functions complete.
This extension lives in the WebMotions.Azure.WebJobs.Extensions.Slack package. Get started easily by either using the binding variable `WebHookUrl` or by using
the app settings/environment variable `AzureWebJobsSlackWebHookUrl`. You can also use an API Key, by using the binding variable `ApiKey` or the app settings/environment variable
`AzureWebJobsSlackWebApiKey`. Other options are available either through the binding attribute or directly in the `SlackMessage` class.

#### Installation

Official packages are available on [NuGet](https://www.nuget.org/packages/WebMotions.Azure.WebJobs.Extensions.Slack).

Unofficial (dev) packages are available on [MyGet](https://www.myget.org/F/webmotions-azure-webjobs-extensions/api/v3/index.json)

```bash
dotnet add package WebMotions.Azure.WebJobs.Extensions.Slack
```

#### Usage

```csharp
using WebMotions.Azure.WebJobs.Extensions.Slack;

[FunctionName("YourFunction")]
public async Task Run(
	[HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req,
	[Slack(WebHookUrl = "https://hooks.slack.com/services/XXXXXXXX/XXXXXXXXXX/XXXXXXXXX", 
		  Channel = "#general")] IAsyncCollector<SlackMessage> messages,
	ILogger logger)
{
	var message = new SlackMessage();
	
	// configure your message
	
	await messages.AddAsync(message);
}
```

Adding the binding to your function automatically registers the extension. If you want more options, you can register the Slack extensions, using `builder.AddSlack()` in your startup code. 
For more information on the Slack binding, see the Slack [samples](https://github.com/webmotions/Azure.WebJobs.Extensions/tree/master/samples/SlackFunctionApp).

#### Limitations

Attachments were not added of part of this extension. The reason behind this is that Slack considers attachments a legacy part of the messaging functionality:
they may change in the future, in ways that reduce their visibility or utility. See the [documentation](https://api.slack.com/messaging/composing/layouts#when-to-use-attachments) for more information.

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)