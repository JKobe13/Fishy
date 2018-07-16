using System;
using System.Collections.Generic;
using System.Text;

namespace Fishy.Infrastructure.DTO
{
    public class OfferWithProductDetails
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public decimal Cost { get; set; }

        public decimal DefaultMargin { get; set; }
    }
}
