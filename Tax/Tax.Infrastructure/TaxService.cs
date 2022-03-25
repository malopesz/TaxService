using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Tax.API.Settings;
using Tax.Infrastructure.Exceptions;
using Tax.Infrastructure.Interface;
using Tax.Infrastructure.Dtos;
using System.Net.Http.Headers;
using System.Collections.Generic;

namespace Tax.Infrastructure
{
    public class TaxService : ITaxService
    {
        private HttpClient _httpClient;
        private readonly TaxApiSettings _taxApiSettings;

        public TaxService(HttpClient httpClient, TaxApiSettings taxApiSettings)
        {            
            _httpClient = httpClient;
            _taxApiSettings = taxApiSettings;
        }

        public async Task<SalesTax> CalculateTaxAsync(int customerId, SalesTaxRequest request)
        {
            var salesTax = new SalesTax();

            var apiService = DetermineApiService(customerId);
            AddHttpClientConfiguration(apiService);

            //Turn request into json
            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() }
            };

            //Post json to endpoint
            var jsonString = JsonSerializer.Serialize(request, options);

            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(apiService.CalculateTaxApiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                salesTax = JsonSerializer.Deserialize<SalesTax>(result, options);
            }
            else
            {
                throw new CalculateTaxException($"{response.Content.ToString()}, Status Code: {response.StatusCode}");
            }

            return salesTax;
        }

        public async Task<TaxRate> GetTaxRateByLocationAsync(int customerId, string zip)
        {
            var taxRate = new TaxRate();

            var apiService = DetermineApiService(customerId);
            AddHttpClientConfiguration(apiService);

            var response = await _httpClient.GetAsync($"{apiService.GetTaxRateByLocationApiUrl}/{zip}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    Converters = { new JsonStringEnumConverter() },
                    WriteIndented = true,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                };

                taxRate = JsonSerializer.Deserialize<TaxRate>(result, options);
            }
            else
            {
                throw new TaxRateLocationException($"{response.Content.ToString()}, Status Code: {response.StatusCode}");
            }

            return taxRate;
        }

        private ApiRequest DetermineApiService(int customerId)
        {
            var apiRequest = new ApiRequest();

            switch (customerId) 
            {
                case 1:
                    apiRequest.CalculateTaxApiUrl = _taxApiSettings.TaxJarApi.Urls.CalculateTax;
                    apiRequest.GetTaxRateByLocationApiUrl = _taxApiSettings.TaxJarApi.Urls.GetTaxRateByLocation;
                    apiRequest.ApiKey = _taxApiSettings.TaxJarApi.TaxJarApiKey;
                    break;
                default:
                    throw new EmptyCustomerException("Could not find a valid api for customer id supplied.");
            }

            return apiRequest;
        }

        private void AddHttpClientConfiguration(ApiRequest apiRequest)
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Token token=\"{apiRequest.ApiKey}\"");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
