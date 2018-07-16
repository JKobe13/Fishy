using Fishy.DAL.Models;
using Fishy.Infrastructure.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fishy.Infrastructure.Interfaces.Services
{
    public interface IOffersServices
    {
        Task<Offer> Get(int id);

        Task<List<OfferWithProductDetails>> GetNavigationList();

        Task<Offer> Add(Offer offer);
    }
}
