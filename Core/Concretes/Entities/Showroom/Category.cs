using Core.Abstracts.Bases;

namespace Core.Concretes.Entities.Showroom
{
    public class Category : BaseEntity
    {
        public required string Name { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; } = [];
    }
}
