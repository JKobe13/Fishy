using Fishy.DAL.Models;
using Fishy.Infrastructure.DTO.API.Input;
using Fishy.Infrastructure.DTO.API.Output;
using Fishy.Infrastructure.Interfaces.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Fishy.Infrastructure.Services
{
    public class ProductApiService
    {
        private readonly HttpClient _httpClient;

        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ProductDto> Get(int id)
        {
            ProductDto result;
            var response = await _httpClient.GetAsync($"/v1/Products/{id}");
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<ProductDto>();
                return result;
            }
            else
                throw new HttpRequestException(response.ReasonPhrase);
        }

        public async Task<List<ProductDto>> GetNavigationList()
        {
            var result = new List<ProductDto>();
            var response = await _httpClient.GetAsync($"/v1/Products");
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<List<ProductDto>>();
            }
            else
                throw new HttpRequestException(response.ReasonPhrase);
            return result;
        }

        public async Task<ProductDto> Add(ProductModifyDto product)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"/v1/Products", stringContent);

            if (!response.IsSuccessStatusCode)
                return null;

            var result = await response.Content.ReadAsAsync<ProductDto>();

            return result;
        }

        public async Task<ProductDto> Modify(ProductModifyDto product)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"/v1/Products", stringContent);

            if (!response.IsSuccessStatusCode)
                return null;

            var result = await response.Content.ReadAsAsync<ProductDto>();

            return result;
        }
    }
}
