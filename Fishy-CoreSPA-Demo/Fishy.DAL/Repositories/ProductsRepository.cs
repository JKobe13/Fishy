using Fishy.DAL.Infrastucture;
using Fishy.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishy.DAL.Repositories
{
    public class ProductsRepository: GenericRepository<Product>, IProductsRepository
    {
        private static IEnumerable<Product> _defaultItems = new List<Product>()
        {
            new Product{Id=1,Name="Pomarańcza",Description="Jest pomarańczowa" },
            new Product{Id=2,Name="Ogień",Description="Może poparzyć" },
            new Product{Id=3,Name="Kasztan",Description="Okrąglutki" },
            new Product{Id=4,Name="Kredka",Description="Wielokolorowe urządzenia do zapisywania spostrzeżeń. Dostępne wyłącznie w kolorze niebieskim" }
        };

        public ProductsRepository() : base(_defaultItems) {}

    }
}
