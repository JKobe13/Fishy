using Fishy.Infrastructure.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Fishy.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return Json(_productService.GetNavigationList());
        }

        // GET: api/Default/5
        [HttpGet("{id}", Name = "Get")]
        public JsonResult Get(int id)
        {
            return Json(_productService.Get(id));
        }

        // POST: api/Default
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Default/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}