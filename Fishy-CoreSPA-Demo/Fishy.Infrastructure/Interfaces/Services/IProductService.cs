using Fishy.DAL.Models;
using System.Collections.Generic;

namespace Fishy.Infrastructure.Interfaces.Services
{
    public interface IProductService
    {
        Product Get(int id);
        List<Product> GetNavigationList();
    }
}
