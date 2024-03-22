using System;
using Newtonsoft.Json;
using System.Text;
using HttpWork.Config;
using HttpWork.Dtos.Requests;
using HttpWork.Dtos.Responses;
using HttpWork.Services.Abstractions;

namespace HttpWork.Services
{
    public class InternalHttpClientService : IInternalHttpClientService
    {
        private readonly IHttpClientFactory _clientFactory;

        public InternalHttpClientService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
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
            }

            var result = await client.SendAsync(httpMessage);

            if (result.IsSuccessStatusCode)
            {
                string resultContent = await result.Content.ReadAsStringAsync();
                Console.WriteLine($"Received response content: {resultContent}");
                var response = JsonConvert.DeserializeObject<TResponse>(resultContent);
                return response!;
            }

            return default(TResponse)!;
        }

    }
}

