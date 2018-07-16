using Fishy.DAL.Models;
using Fishy.DAL.Repositories;
using Fishy.Infrastructure.DTO;
using Fishy.Infrastructure.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fishy.Infrastructure.Services
{
    public class OffersServices : IOffersServices
    {
        private IOffersRepository _offerRepository;
        private IProductsRepository _productRepository;

        public OffersServices(IOffersRepository offerRepository, IProductsRepository productRepository)
        {
            _offerRepository = offerRepository;
            _productRepository = productRepository;
        }

        public async Task<List<OfferWithProductDetails>> GetNavigationList()
        {
            var offers = _offerRepository.GetAll().ToList();
            var productsDict = _productRepository.Get(offers.Select(x => x.ProductId).Distinct()).ToDictionary(x => x.Id);

            var result = 
                offers.Select(singleOffer => new OfferWithProductDetails {
                    Id = singleOffer.Id,
                    Cost = singleOffer.Cost,
                    DefaultMargin = singleOffer.DefaultMargin,
                    ProductName = productsDict.ContainsKey(singleOffer.ProductId)?productsDict[singleOffer.ProductId].Name:string.Empty
                }).ToList();

            return result;
        }

        public async Task<Offer> Get(int id)
        {
            var result = _offerRepository.Get(id);
            return result;
        }

        public async Task<Offer> Add(Offer product)
        {
            var result = _offerRepository.Add(product);

            return result;
        }

    }
}
