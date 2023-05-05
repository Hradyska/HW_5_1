using HTTPClientFactoryPractice.Dtos.Requests;
using HTTPClientFactoryPractice.Dtos.Responses;
using HTTPClientFactoryPractice.Dtos;
using HTTPClientFactoryPractice.Config;
using HTTPClientFactoryPractice.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace HTTPClientFactoryPractice.Services
{
    public class UserService : IUserService
    {
        private readonly IInternalHTTPClientService _httpClientService;
        private readonly ILogger<UserService> _logger;
        private readonly APIOption _options;
        private readonly string _userApi = "api/users";

        public UserService(
            IInternalHTTPClientService httpClientService,
            IOptions<APIOption> options,
            ILogger<UserService> logger)
        {
            _httpClientService = httpClientService;
            _logger = logger;
            _options = options.Value;
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var result = await _httpClientService.SendAsync<BaseResponse<UserDto>, object>($"{_options.Host}{_userApi}/{id}", HttpMethod.Get);

            if (result?.Data != null)
            {
                _logger.LogInformation($"User with id = {result.Data.Id} was found");
            }

            return result?.Data;
        }

        public async Task<UserResponse> CreateUserAsync(string name, string job)
        {
            var result = await _httpClientService.SendAsync<UserResponse, UserRequest>(
                $"{_options.Host}{_userApi}",
                HttpMethod.Post,
                new UserRequest()
                {
                    Job = job,
                    Name = name
                });

            if (result != null)
            {
                _logger.LogInformation($"User with id = {result?.Id} was created");
                _logger.LogInformation(JsonConvert.SerializeObject(result));
            }

            return result;
        }

        public async Task<List<UserDto>> GetListUsersAsync()
        {
            var result = await _httpClientService.SendAsync<ListResponse<UserDto>, object>($"{_options.Host}{_userApi}", HttpMethod.Get);
            if (result?.Data != null)
            {
                _logger.LogInformation($"{result.Total} users were found");
                _logger.LogInformation(JsonConvert.SerializeObject(result));
            }

            return result?.Data;
        }

        public async Task<UserResponse> PutUserAsync(int id, string name, string job)
        {
            var result = await _httpClientService.SendAsync<UserResponse, UserRequest>(
                $"{_options.Host}{_userApi}/{id}",
                HttpMethod.Put,
                new UserRequest()
                {
                    Job = job,
                    Name = name
                });

            if (result != null)
            {
                _logger.LogInformation($"User with id = {id} was updated whith Put");
                _logger.LogInformation(JsonConvert.SerializeObject(result));
            }

            return result;
        }

        public async Task<UserResponse> PatchUserAsync(int id, string name = null, string job = null)
        {
            var result = await _httpClientService.SendAsync<UserResponse, UserRequest>(
                $"{_options.Host}{_userApi}/{id}",
                HttpMethod.Patch,
                new UserRequest()
                {
                    Job = job,
                    Name = name
                });

            if (result != null)
            {
                _logger.LogInformation($"User with id = {id} was updated whith Patch");
                _logger.LogInformation(JsonConvert.SerializeObject(result));
            }

            return result;
        }

        public async Task DeleteUserAsync(int id)
        {
            _ = await _httpClientService.SendAsync<object, object>(
                $"{_options.Host}{_userApi}/{id}",
                HttpMethod.Delete);
            _logger.LogInformation($"User Id = {id} deleted");
        }
    }
}
