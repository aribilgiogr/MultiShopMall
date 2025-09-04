using Core.Abstracts.Bases;

namespace Core.Concretes.Entities.Showroom
{
    public class ProductModel : BaseEntity
    {
        public required string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; } = [];
    }
}
