using Fishy.DAL.Infrastucture;
using Fishy.DAL.Models;
using System.Collections.Generic;

namespace Fishy.DAL.Repositories
{
    public class OffersRepository : GenericRepository<Offer>, IOffersRepository
    {
        private static IEnumerable<Offer> _defaultItems = new List<Offer>()
        {
            new Offer{Id=1,ProductId=1,Cost= 10, DefaultMargin = 0.2M },
            new Offer{Id=2,ProductId=2,Cost= 20, DefaultMargin = 0.2M },
            new Offer{Id=3,ProductId=2,Cost= 18, DefaultMargin = 0.2M },
            new Offer{Id=4,ProductId=2,Cost= 23, DefaultMargin = 0.2M },
        };

        public OffersRepository() : base(_defaultItems) { }

    }
}
