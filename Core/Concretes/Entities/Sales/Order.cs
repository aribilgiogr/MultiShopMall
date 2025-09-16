using Core.Abstracts.Bases;
using Core.Concretes.Entities.Accounts;
using Core.Concretes.Enums;

namespace Core.Concretes.Entities.Sales
{
    public class Order : BaseEntity
    {
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
        public decimal TotalDue { get; set; }
        public decimal TotalDiscount { get; set; }
        public int ItemCount { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public virtual ICollection<Vendor> Vendors { get; set; } = [];
    }
}
