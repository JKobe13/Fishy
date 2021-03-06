﻿using Fishy.DAL.Models;
using Fishy.Infrastructure.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fishy.WebApi.Controllers
{
    [Route("v1/products/{productId}/offers")]
    public class OffersController : Controller
    {
        private IOffersServices _offerService;

        public OffersController(IOffersServices offerService)
        {
            _offerService = offerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOffers()
        {
            var products = await _offerService.GetNavigationList();
            return new ObjectResult(products);
        }

        [HttpGet("{id}", Name = "GetOffer")]
        public IActionResult GetOffer([FromRoute]int productId, [FromRoute]int id)
        {
            return new ObjectResult(_offerService.Get(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]Offer model)
        {
            var createdProduct = _offerService.Add(model);

            return CreatedAtRoute("Get", new { id = createdProduct.Id },createdProduct);
        }
    }
}