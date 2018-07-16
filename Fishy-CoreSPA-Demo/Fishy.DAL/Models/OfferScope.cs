using System;
using System.Collections.Generic;
using System.Text;

namespace Fishy.DAL.Models
{
    class OfferScope
    {
        public int OfferId { get; set; }

        public int ScopeId { get; set; }

        public decimal ScopeMargin { get; set; }
    }
}
