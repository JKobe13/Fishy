using Fishy.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fishy.Infrastructure.Interfaces.Services
{
    public interface IProductsServices
    {
        Product Get(int id);

        List<Product> GetNavigationList();

        Product Add(Product product);

        Product Modify(Product product);
    }
}
