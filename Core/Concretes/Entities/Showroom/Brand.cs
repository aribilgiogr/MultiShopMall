using Core.Abstracts.Bases;

namespace Core.Concretes.Entities.Showroom
{
    public class Brand : BaseEntity
    {
        public required string Name { get; set; }
        public string? Logo { get; set; }
        public virtual ICollection<Product> Products { get; set; } = [];
    }
}
