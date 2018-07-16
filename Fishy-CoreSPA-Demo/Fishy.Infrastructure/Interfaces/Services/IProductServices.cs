using Fishy.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fishy.Infrastructure.Interfaces.Services
{
    public interface IProductsServices
    {
        Task<Product> Get(int id);

        Task<List<Product>> GetNavigationList();

        Task<Product> Add(Product product);
    }
}
