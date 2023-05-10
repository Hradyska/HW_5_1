using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTTPClientFactoryPractice.Dtos.Responses;
using HTTPClientFactoryPractice.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HTTPClientFactoryPractice.Services
{
    internal class InternalHTTPClientService : IInternalHTTPClientService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<InternalHTTPClientService> _logger;

        public InternalHTTPClientService(IHttpClientFactory clientFactory, ILogger<InternalHTTPClientService> logger)
        {
            _clientFactory = clientFactory;
            _logger = logger;
        }

        public async Task<TResponse> SendAsync<TResponse, TRequest>(string url, HttpMethod method, TRequest content = null)
            where TRequest : class
        {
            var client = _clientFactory.CreateClient();

            var httpMessage = new HttpRequestMessage();
            httpMessage.RequestUri = new Uri(url);
            httpMessage.Method = method;

            if (content != null)
            {
                httpMessage.Content =
                    new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
                string stringcont = httpMessage.Content.Headers.ToString();
            }

            var result = await client.SendAsync(httpMessage);
            if (result.IsSuccessStatusCode)
            {
                _logger.LogInformation($"Status: {result.StatusCode}");
                var resultContent = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<TResponse>(resultContent);
                _logger.LogInformation($"Response: {response}");
                return response!;
            }

            _logger.LogInformation($"Status: {result.StatusCode}");

            var resultContent1 = await result.Content.ReadAsStringAsync();
            if (resultContent1 != null)
            {
                var response1 = JsonConvert.DeserializeObject<ErrorResponse>(resultContent1);

                _logger.LogInformation($"Response: {response1.Error}");
            }

            return default(TResponse) !;
        }
    }
}
