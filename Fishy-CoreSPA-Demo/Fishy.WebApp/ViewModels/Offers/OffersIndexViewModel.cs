using Fishy.DAL.Models;
using System.Collections.Generic;

namespace Fishy.WebApp.ViewModels.Offers
{
    public class OffersIndexViewModel
    {
        public List<OfferGridRowViewModel> OffersCollection { get; set; }

        public OffersIndexViewModel()
        {
            OffersCollection = new List<OfferGridRowViewModel>();
        }
    }
}
