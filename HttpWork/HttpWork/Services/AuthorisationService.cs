using System;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using HttpWork.Dtos;
using HttpWork.Config;
using HttpWork.Dtos.Requests;
using HttpWork.Dtos.Responses;
using HttpWork.Services.Abstractions;

namespace HttpWork.Services
{
    public class AuthorisationService : IAuthorisationService
    {
        private const string AuthorisationUrl = "https://reqres.in";
        private const string LoginUrl = "https://reqres.in";
        private readonly IInternalHttpClientService _httpClientService;
        private readonly ILogger<UserService> _logger;
        private readonly ApiOption _options;

        public AuthorisationService(
            IInternalHttpClientService httpClientService,
            IOptions<ApiOption> options,
            ILogger<UserService> logger)
        {
            _httpClientService = httpClientService;
            _logger = logger;
            _options = options.Value;
        }

        public async Task<RegisterUserResponse> RegistrationSuccessful(string email, string password)
        {
            var result = await _httpClientService.SendAsync<RegisterUserResponse, RegisterUserRequest>(
                $"{_options.Host}{Constants.AuthorisationUrl}register",
                HttpMethod.Post,
                new RegisterUserRequest
                {
                    Email = email,
                    Password = password
                });

            if (result != null)
            {
                _logger.LogInformation($"User successfully registered");
            }
            else
            {
                _logger.LogInformation($"User registration failed");
            }

            return result;
        }
        public async Task<RegisterUserResponse> RegistrationUnsuccessful(string email)
        {
            var result = await _httpClientService.SendAsync<RegisterUserResponse, RegisterUserRequest>(
                $"{_options.Host}{Constants.AuthorisationUrl}register",
                HttpMethod.Post,
                new RegisterUserRequest
                {
                    Email = email,
                });

            if (result != null)
            {
                _logger.LogInformation($"User registration failed. User ID: {result.Id}");
            }
            else
            {
                _logger.LogInformation($"User registration unsuccessful (email already in use)");
            }

            return result;
        }

        public async Task<RegisterUserResponse> LoginSuccessful(string email, string password)
        {
            var result = await _httpClientService.SendAsync<RegisterUserResponse, RegisterUserRequest>(
                $"{_options.Host}{Constants.LoginUrl}login",
                HttpMethod.Post,
                new RegisterUserRequest
                {
                    Email = email,
                    Password = password
                });

            if (result != null)
            {
                _logger.LogInformation($"User successfully logged in");
            }
            else
            {
                _logger.LogInformation($"User login failed");
            }

            return result;
        }
        public async Task<RegisterUserResponse> LoginUnsuccessful(string email)
        {
            var result = await _httpClientService.SendAsync<RegisterUserResponse, RegisterUserRequest>(
                $"{_options.Host}{Constants.LoginUrl}login",
                HttpMethod.Post,
                new RegisterUserRequest
                {
                    Email = email,
                });

            if (result != null)
            {
                _logger.LogInformation($"User login failed");
            }
            else
            {
                _logger.LogInformation($"User login unsuccessful (user not found)");
            }

            return result;
        }
    }
}

