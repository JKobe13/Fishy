using Fishy.DAL.Models;
using Fishy.Infrastructure.DTO;
using Fishy.Infrastructure.Interfaces.Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Fishy.Infrastructure.Services
{
    public class OfferApiService: IOffersServices
    {
        private readonly HttpClient _httpClient;

        public OfferApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Offer> Get(int id)
        {
            Offer result;
            var response = await _httpClient.GetAsync($"/v1/Offers/{id}");
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<Offer>();
                return result;
            }
            else
                throw new HttpRequestException(response.ReasonPhrase);
        }

        public async Task<List<OfferWithProductDetails>> GetNavigationList()
        {
            var result = new List<OfferWithProductDetails>();
            var response =  await _httpClient.GetAsync($"/v1/Offers");
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<List<OfferWithProductDetails>>();
            }
            else
                throw new HttpRequestException(response.ReasonPhrase);
            return result;
        }

        public async Task<Offer> Add(Offer product)
        {
            return product;
        }


    }
}
