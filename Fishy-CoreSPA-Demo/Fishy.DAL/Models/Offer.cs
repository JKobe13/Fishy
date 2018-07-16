using Fishy.DAL.Infrastucture;

namespace Fishy.DAL.Models
{
    public class Offer : Entity
    {
        public int ProductId { get; set; }

        public decimal Cost { get; set; }

        public decimal DefaultMargin { get; set; }
    }
}
