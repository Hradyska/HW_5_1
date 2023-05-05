﻿using HTTPClientFactoryPractice.Config;
using HTTPClientFactoryPractice.Dtos.Requests;
using HTTPClientFactoryPractice.Dtos.Responses;
using HTTPClientFactoryPractice.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HTTPClientFactoryPractice.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly IInternalHTTPClientService _httpClientService;
        private readonly ILogger<RegisterService> _logger;
        private readonly APIOption _options;
        private readonly string _registerApi = "api/register";
        private readonly string _loginApi = "api/login";

        public RegisterService(
            IInternalHTTPClientService httpClientService,
            IOptions<APIOption> options,
            ILogger<RegisterService> logger)
        {
            _httpClientService = httpClientService;
            _logger = logger;
            _options = options.Value;
        }

        public async Task<RegisterResponse> RegistrationAsync(string email = null, string password = null)
        {
            var create = await _httpClientService.SendAsync<RegisterResponse, RegisterRequest>(
                $"{_options.Host}{_registerApi}",
                HttpMethod.Post,
                new RegisterRequest
                {
                    Email = email,
                    Password = password
                });
            if (create != null)
            {
                _logger.LogInformation($"Registration was saccessed");
            }

            return create;
        }

        public async Task<RegisterResponse> LoginAsync(string email = null, string password = null)
        {
            var create = await _httpClientService.SendAsync<RegisterResponse, RegisterRequest>(
                $"{_options.Host}{_loginApi}",
                HttpMethod.Post,
                new RegisterRequest
                {
                     Email = email,
                     Password = password
                });

            // ew LoginRequest
            // {
            //    FormContent = new FormUrlEncodedContent(new[]
            //    {
            //        new KeyValuePair<string, string>("email", email),
            //        new KeyValuePair<string, string>("password", password)
            //    })
            // });
            if (create != null)
            {
                _logger.LogInformation($"Login was saccessed");
            }

            return create;
        }
    }
}
