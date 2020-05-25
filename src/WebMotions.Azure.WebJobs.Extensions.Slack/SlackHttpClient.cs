using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models;

namespace WebMotions.Azure.WebJobs.Extensions.Slack
{
    public class SlackHttpClient : ISlackHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<SlackHttpClient> _logger;

        public SlackHttpClient(HttpClient httpClient, ILogger<SlackHttpClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task PostMessageAsync(SlackContext context, SlackMessage message)
        {
            var httpRequestMessage = new HttpRequestMessage();

            if (!string.IsNullOrWhiteSpace(context.ApiKey))
            {
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.ApiKey);
                httpRequestMessage.RequestUri = new Uri("https://slack.com/api/chat.postMessage");
            }
            else
            {
                httpRequestMessage.RequestUri = new Uri(context.WebHookUrl);
            }

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
#if DEBUG
            var formatting = Newtonsoft.Json.Formatting.Indented;
#else
            var formatting = Newtonsoft.Json.Formatting.None;
#endif
            var messageJson = JsonConvert.SerializeObject(message, formatting, jsonSerializerSettings);
            httpRequestMessage.Content = new StringContent(messageJson, Encoding.UTF8, "application/json");
            httpRequestMessage.Method = HttpMethod.Post;

            _logger.LogDebug("Sending slack message {Id}", message.Id.ToString("D"));
            _logger.LogTrace("Json Message: {Message}", messageJson);
            var response = await _httpClient.SendAsync(httpRequestMessage);
            if (!response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                _logger.LogError("Slack message {Id} failed to send: {StatusCode} - {ResponsePhrase} - {Body}", message.Id, response.StatusCode, response.ReasonPhrase, body);
            }
            _logger.LogDebug("Sent slack message {Id}", message.Id.ToString("D"));
        }
    }
}