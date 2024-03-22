using System;
using Microsoft.Extensions.Options;
using HttpWork.Config;
using HttpWork.Dtos.Requests;
using HttpWork.Dtos.Responses;
using HttpWork.Services.Abstractions;
using HttpWork.Dtos;

using IResourceService = HttpWork.Services.Abstractions.IResourceService;

namespace HttpWork.Services
{
    public class ResourceService : IResourceService
    {
        private const string ResourceUrl = "https://reqres.in";
        private readonly IInternalHttpClientService _httpClientService;
        private readonly ILogger<UserService> _logger;
        private readonly ApiOption _options;

        public ResourceService(
            IInternalHttpClientService httpClientService,
            IOptions<ApiOption> options,
            ILogger<UserService> logger)
        {
            _httpClientService = httpClientService;
            _logger = logger;
            _options = options.Value;
        }
        public async Task<List<ResourceDto>> GetUsersResource()
        {
            var result = await _httpClientService.SendAsync<BaseListResponse<ResourceDto>, object>($"{_options.Host}{Constants.ResourceUrl}unknown",
                HttpMethod.Get);

            if (result?.Data == null)
            {
                _logger.LogInformation($"Resource data not found");
            }
            else
            {
                _logger.LogInformation($"Received {result.Data.Count} resources from the API");
            }

            return result.Data;
        }
        public async Task<List<ResourceDto>> SingleUserResource()
        {
            var result = await _httpClientService.SendAsync<BaseListResponse<ResourceDto>, object>($"{_options.Host}{Constants.ResourceUrl}2",
                HttpMethod.Get);

            if (result?.Data == null)
            {
                _logger.LogInformation($"Sigle user not found");
            }
            else
            {
                _logger.LogInformation($"users {result.Data}found");
            }

            return result.Data;
        }

        public async Task<List<ResourceDto>> SingleResourceNotFound()
        {
            var result = await _httpClientService.SendAsync<BaseListResponse<ResourceDto>, object>($"{_options.Host}{Constants.ResourceUrl}23",
                HttpMethod.Get);

            if (result == null)
            {
                _logger.LogInformation($"404 (Not Found)");
                return null;
            }

            return result.Data;

        }
    }
}

