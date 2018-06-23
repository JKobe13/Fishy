using Fishy.DAL.Models;
using Fishy.Infrastructure.Interfaces.Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Fishy.Infrastructure.Services
{
    public class ProductApiService: IProductServices
    {
        private readonly HttpClient _httpClient;

        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Product> Get(int id)
        {
            Product result;
            var response = await _httpClient.GetAsync($"/v1/Product/{id}");
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<Product>();
                return result;
            }
            else
                throw new HttpRequestException(response.ReasonPhrase);
        }

        public async Task<List<Product>> GetNavigationList()
        {
            var result = new List<Product>();
            var response =  await _httpClient.GetAsync($"/v1/Product");
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<List<Product>>();
            }
            else
                throw new HttpRequestException(response.ReasonPhrase);
            return result;
        }

        public async Task<Product> Add(Product product)
        {
            return product;
        }


    }
}
