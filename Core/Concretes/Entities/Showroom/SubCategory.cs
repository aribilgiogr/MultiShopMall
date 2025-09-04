using Core.Abstracts.Bases;

namespace Core.Concretes.Entities.Showroom
{
    public class SubCategory : BaseEntity
    {
        public required string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<Product> Products { get; set; } = [];
    }
}
