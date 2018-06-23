using Fishy.DAL.Models;
using Fishy.DAL.Repositories;
using Fishy.Infrastructure.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace Fishy.Infrastructure.Services
{
    public class ProductServices: IProductService
    {
        private IProductsRepository _productRepository;

        ProductServices(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetNavigationList()
        {
            var result = _productRepository.GetAll().ToList();
            return result;
        }

        public Product Get(int id)
        {
            var result = _productRepository.Get(id);
            return result;
        }

    }
}
