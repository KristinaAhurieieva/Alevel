using System;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using HttpWork.Config;
using HttpWork.Dtos.Requests;
using HttpWork.Dtos.Responses;
using HttpWork.Services.Abstractions;
using HttpWork.Dtos;

namespace HttpWork.Services
{
    public class UserService : IUserService
    {
        private const string baseUrl = "https://reqres.in";
        private readonly IInternalHttpClientService _httpClientService;
        private readonly ILogger<UserService> _logger;
        private readonly ApiOption _options;

        public UserService(
            IInternalHttpClientService httpClientService,
            IOptions<ApiOption> options,
            ILogger<UserService> logger)
        {
            _httpClientService = httpClientService;
            _logger = logger;
            _options = options.Value;
        }
        public async Task<List<UserDto>> GetUsers()
        {
            var result = await _httpClientService.SendAsync<BaseListResponse<UserDto>, object>($"{_options.Host}{Constants.UserUrl}?page=2",
                HttpMethod.Get);

            if (result?.Data == null)
            {
                _logger.LogInformation($"User data not found");
            }

            return result.Data;
        }

        public async Task<List<UserDto>> SingleUser()
        {
            var result = await _httpClientService.SendAsync<BaseListResponse<UserDto>, object>(
                $"{_options.Host}{Constants.UserUrl}2",
                HttpMethod.Get);

            if (result?.Data == null)
            {
                _logger.LogInformation($"User not found");
                return null;
            }
            else
            {
                _logger.LogInformation($"Userfound");
            }

            return result.Data ?? new List<UserDto>();
        }


        public async Task<List<UserDto>> SingleUserNotFound()
        {
            var result = await _httpClientService.SendAsync<BaseListResponse<UserDto>, object>($"{_options.Host}{Constants.UserUrl}23", HttpMethod.Get);

            if (result == null)
            {
                _logger.LogInformation($"404 (Not Found)");
                return null;
            }

            return result.Data;

        }

        public async Task<UserResponse> CreateUser(string name, string job)
        {
            var result = await _httpClientService.SendAsync<UserResponse, UserRequest>(
                $"{_options.Host}{Constants.UserUrl}",
                HttpMethod.Post,
                new UserRequest()
                {
                    Job = job,
                    Name = name
                });

            if (result != null)
            {
                _logger.LogInformation($"User with id = {result?.Id} was created");
            }

            return result;
        }
        public async Task<UserResponse> UpdateUser(string name, string job)
        {
            var result = await _httpClientService.SendAsync<UserResponse, UserRequest>(
                $"{_options.Host}{Constants.UserUrl}2",
                HttpMethod.Put,
                new UserRequest()
                {
                    Job = job,
                    Name = name
                });

            if (result != null)
            {
                _logger.LogInformation($"Update User = {result?.Name} {result?.Job}");
            }

            return result;
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var result = await _httpClientService.SendAsync<BaseResponse<UserDto>, object>($"{_options.Host}{Constants.UserUrl}{id}", HttpMethod.Get);

            if (result?.Data != null)
            {
                _logger.LogInformation($"User with id = {result.Data.Id} was found. Name: {result.Data.FirstName} {result.Data.LastName}");
            }
            else
            {
                _logger.LogInformation($"User with id = {id} was not found.");
            }

            return result?.Data;
        }

        public async Task<UserResponse> PatchUser(string name, string job)
        {
            var result = await _httpClientService.SendAsync<UserResponse, UserRequest>(
                $"{_options.Host}{Constants.UserUrl}",
                HttpMethod.Patch,
                new UserRequest()
                {
                    Job = job,
                    Name = name
                });

            if (result != null)
            {
                _logger.LogInformation($"Update User = {result?.Name} {result?.Job}");
            }


            return result;
        }

        public async Task<UserDto> DeleteUser()
        {
            var result = await _httpClientService.SendAsync<BaseResponse<UserDto>, object>($"{_options.Host}{Constants.UserUrl}2",
                HttpMethod.Delete);

            if (result?.Data != null)
            {
                _logger.LogInformation($"User delete");
            }
            else
            {
                _logger.LogInformation($"User not deleted or not found ");
            }

            return result?.Data;
        }


        public async Task<UserDto> DelayedResponse()
        {
            var result = await _httpClientService.SendAsync<BaseResponse<UserDto>, object>($"{_options.Host}{Constants.UserUrl}?delay=3", HttpMethod.Get);

            if (result?.Data != null)
            {
                _logger.LogInformation($"Action delayed");
            }
            else
            {
                _logger.LogInformation($"Action not delayed");
            }

            return result?.Data;
        }
    }
}

