using Fishy.DAL.Models;
using Fishy.DAL.Repositories;
using Fishy.Infrastructure.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fishy.Infrastructure.Services
{
    public class ProductsServices : IProductsServices
    {
        private IProductsRepository _productRepository;

        public ProductsServices(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetNavigationList()
        {
            var result = _productRepository.GetAll().ToList();
            return result;
        }

        public  Product Get(int id)
        {
            var result = _productRepository.Get(id);
            return result;
        }

        public  Product Add(Product product)
        {
            var result = _productRepository.Add(product);

            return result;
        }
        public Product Modify(Product product)
        {
            var result = _productRepository.Modify(product);
            return result;
        }
    }
}
