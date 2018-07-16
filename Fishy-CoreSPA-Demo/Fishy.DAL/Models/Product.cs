using Fishy.DAL.Infrastucture;

namespace Fishy.DAL.Models
{
    public class Product : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
