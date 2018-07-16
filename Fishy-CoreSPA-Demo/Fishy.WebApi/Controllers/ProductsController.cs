using Fishy.DAL.Models;
using Fishy.Infrastructure.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fishy.WebApi.Controllers
{
    [Route("v1/[controller]")]
    public class ProductsController : Controller
    {
        private IProductsServices _productsService;

        public ProductsController(IProductsServices productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productsService.GetNavigationList();
            return new ObjectResult(products);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult Get(int id)
        {
            return new ObjectResult(_productsService.Get(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]Product model)
        {
            var createdProduct = _productsService.Add(model);

            return CreatedAtRoute("Get", new { id = createdProduct.Id },createdProduct);
        }
    }
}