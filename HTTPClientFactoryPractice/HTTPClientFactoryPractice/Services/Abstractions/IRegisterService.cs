﻿using HTTPClientFactoryPractice.Dtos.Responses;

namespace HTTPClientFactoryPractice.Services.Abstractions
{
    public interface IRegisterService
    {
        public Task<RegisterResponse> RegistrationAsync(string email = null, string password = null);
        public Task<RegisterResponse> LoginAsync(string email = null, string password = null);
    }
}
