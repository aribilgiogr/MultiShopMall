using Core.Abstracts.Bases;
using Core.Concretes.Entities.Accounts;

namespace Core.Concretes.Entities.Sales
{
    public class Cart : BaseEntity
    {
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; } = [];
    }
}
