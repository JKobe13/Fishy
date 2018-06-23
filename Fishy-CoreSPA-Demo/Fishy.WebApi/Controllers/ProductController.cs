using Fishy.DAL.Models;
using Fishy.Infrastructure.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fishy.WebApi.Controllers
{
    [Route("v1/[controller]")]
    public class ProductController : Controller
    {
        private IProductServices _productService;

        public ProductController(IProductServices productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetNavigationList();
            return new ObjectResult(products);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            return new ObjectResult(_productService.Get(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]Product model)
        {
            var createdProduct = _productService.Add(model);

            return CreatedAtRoute("Get", new { id = createdProduct.Id },createdProduct);
        }
    }
}