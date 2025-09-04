using Core.Abstracts.Bases;
using Core.Concretes.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.Entities.Accounts
{
    public class Customer : BaseEntity
    {
        public required string MemberId { get; set; }
        public virtual Member? Member { get; set; }
        public virtual ICollection<Cart> Carts { get; set; } = [];
        public virtual ICollection<Order> Orders { get; set; } = [];
    }
}
