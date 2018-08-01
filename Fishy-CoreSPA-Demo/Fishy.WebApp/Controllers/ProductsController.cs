using AutoMapper;
using Fishy.Infrastructure.DTO.API.Input;
using Fishy.Infrastructure.DTO.API.Output;
using Fishy.Infrastructure.Interfaces.Services;
using Fishy.Infrastructure.Services;
using Fishy.WebApp.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fishy.WebApp.Controllers
{
    public class ProductsController : Controller
    {
        private ProductApiService _productServices;

        public ProductsController(ProductApiService productServices)
        {
            _productServices = productServices;
        }

        public async Task<ActionResult> Index()
        {
            var products = await _productServices.GetNavigationList();

            var data = new ProductsIndexViewModel
            {
                ProductsCollection = Mapper.Map<List<ProductViewModel>>(products)
            };

            return View("Index", data);
        }

        [HttpGet]
        public async Task<ActionResult> ModifyProduct(int id = 0)
        {
            ProductViewModel model;
            if (id == 0)
            {
                ViewBag.Title = "Dodaj nowy produkt";
                model = new ProductViewModel();
            }
            else
            {
                var product = await _productServices.Get(id);
                if (product == null) return NotFound();
                ViewBag.Title = $"Edytuj produkt {product.Name.ToUpper()}";
                model = Mapper.Map<ProductViewModel>(product);
            }

            return View("ModifyProduct", model);
        }

        [HttpPost]
        public async Task<ActionResult> ModifyProduct(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var productModifyDto = Mapper.Map<ProductModifyDto>(product);
                ProductDto productDto = product.Id == 0
                    ? await _productServices.Add(productModifyDto)
                    : await _productServices.Modify(productModifyDto);

                var model = Mapper.Map<ProductViewModel>(productDto);
                ViewBag.Title = $"Edytuj produkt {product.Name.ToUpper()}";
                return View("ModifyProduct", model);
            }

            ViewBag.Title = "Dodaj nowy produkt";
            return View("ModifyProduct", product);
        }
    }
}