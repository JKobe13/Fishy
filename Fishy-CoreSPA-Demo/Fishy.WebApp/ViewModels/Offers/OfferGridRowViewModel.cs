using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fishy.WebApp.ViewModels.Offers
{
    public class OfferGridRowViewModel
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public decimal Cost { get; set; }

        public decimal DefaultMargin { get; set; }

        public decimal Price { get { return Cost * (1 + DefaultMargin); } }
    }
}
