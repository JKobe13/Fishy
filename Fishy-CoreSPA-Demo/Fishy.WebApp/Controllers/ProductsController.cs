using Fishy.Infrastructure.Interfaces.Services;
using Fishy.WebApp.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Fishy.WebApp.Controllers
{
    public class ProductsController : Controller
    {
        private IProductServices _productServices;

        public ProductsController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        public async Task<ActionResult> Index()
        {
            var data = new ProductIndexViewModel
            {
                ProductsCollection = await _productServices.GetNavigationList()
            };

            return View("Index",data);
        }
    }
}