using System.Net.Http;
using System.Net.Http.Json; // Добавьте это пространство имен для использования PostAsJsonAsync
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using AddressStandardizationService.models;

namespace AddressStandardizationService.Services
{
    public class DadataService : IDadataService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<DadataService> _logger;

        public DadataService(HttpClient httpClient, ILogger<DadataService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<AddressResponse> StandardizeAddressAsync(AddressRequest request)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("", request);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                var standardizedAddress = JsonConvert.DeserializeObject<AddressResponse>(result);
                return standardizedAddress;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP request error while standardizing address");
                throw new Exception("HTTP request error while standardizing address", ex);
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "JSON deserialization error while standardizing address");
                throw new Exception("JSON deserialization error while standardizing address", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error standardizing address");
                throw new Exception("Error standardizing address", ex);
            }
        }
    }
}