using Fishy.DAL.Models;
using Fishy.DAL.Repositories;
using Fishy.Infrastructure.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fishy.Infrastructure.Services
{
    public class ProductServices : IProductServices
    {
        private IProductsRepository _productRepository;

        public ProductServices(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetNavigationList()
        {
            var result = _productRepository.GetAll().ToList();
            return result;
        }

        public async Task<Product> Get(int id)
        {
            var result = _productRepository.Get(id);
            return result;
        }

        public async Task<Product> Add(Product product)
        {
            var result = _productRepository.Add(product);

            return result;
        }

    }
}
