using HTTPClientFactoryPractice.Config;
using HTTPClientFactoryPractice.Dtos;
using HTTPClientFactoryPractice.Dtos.Responses;
using HTTPClientFactoryPractice.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace HTTPClientFactoryPractice.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IInternalHTTPClientService _httpClientService;
        private readonly ILogger<ResourceService> _logger;
        private readonly APIOption _options;
        private readonly string _resourceApi = "api/unknown";
        public ResourceService(
            IInternalHTTPClientService httpClientService,
            IOptions<APIOption> options,
            ILogger<ResourceService> logger)
        {
            _httpClientService = httpClientService;
            _logger = logger;
            _options = options.Value;
        }

        public async Task<List<ResourceDto>> GetAllResourcesAsync()
        {
            var result = await _httpClientService.SendAsync<ListResponse<ResourceDto>, object>($"{_options.Host}{_resourceApi}", HttpMethod.Get);

            if (result?.Data != null)
            {
                _logger.LogInformation($"Resource with id = {result.Total} was found");
                _logger.LogInformation(JsonConvert.SerializeObject(result));
            }

            return result?.Data;
        }

        public async Task<ResourceDto> GetResourceByIDAsync(int id)
        {
            var result = await _httpClientService.SendAsync<BaseResponse<ResourceDto>, object>($"{_options.Host}{_resourceApi}/{id}", HttpMethod.Get);

            if (result?.Data != null)
            {
                _logger.LogInformation($"Resource with id = {result.Data.Id} was found");
                _logger.LogInformation(JsonConvert.SerializeObject(result));
            }

            return result?.Data;
        }
}
}
