using Fishy.Infrastructure.Interfaces.Services;
using Fishy.WebApp.ViewModels.Offers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Fishy.WebApp.Controllers
{
    public class OffersController : Controller
    {
        private IOffersServices _offerServices;

        public OffersController(IOffersServices offerServices)
        {
            _offerServices = offerServices;
        }

        public async Task<ActionResult> Index()
        {
            var data = new OffersIndexViewModel();

            foreach (var singleOffer in await _offerServices.GetNavigationList())
            {
                data.OffersCollection.Add(new OfferGridRowViewModel
                {
                    Id = singleOffer.Id,
                    ProductName = singleOffer.ProductName,
                    Cost = singleOffer.Cost,
                    DefaultMargin = singleOffer.DefaultMargin
                });
            }

            return View("Index", data);
        }
    }
}