using Fishy.DAL.Models;
using Fishy.Infrastructure.DTO.API.Input;
using Fishy.Infrastructure.DTO.API.Output;
using Fishy.Infrastructure.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fishy.WebApi.Controllers
{
    [Route("v1/products")]
    public class ProductsController : Controller
    {
        private IProductsServices _productsService;

        public ProductsController(IProductsServices productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public  IActionResult GetProducts()
        {
            var products = _productsService.GetNavigationList();

            var result = AutoMapper.Mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult Get(int id)
        {
            var product = _productsService.Get(id);

            if(product == null)
            {
                return NotFound();
            }

            var result = AutoMapper.Mapper.Map<ProductDto>(product);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody]ProductModifyDto product)
        {
            var model = AutoMapper.Mapper.Map<Product>(product);
            var createdProduct = _productsService.Add(model);
            var productDto = AutoMapper.Mapper.Map<ProductDto>(createdProduct);

            return CreatedAtRoute("GetProduct", new { id = productDto.Id }, productDto);
        }

        [HttpPut]
        public IActionResult EditProduct([FromBody]ProductModifyDto product)
        {
            var model = AutoMapper.Mapper.Map<Product>(product);
            var createdProduct = _productsService.Modify(model);
            var productDto = AutoMapper.Mapper.Map<ProductDto>(createdProduct);

            return CreatedAtRoute("GetProduct", new { id = productDto.Id }, productDto);
        }
    }
}