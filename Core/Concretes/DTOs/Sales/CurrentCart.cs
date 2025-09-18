using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.DTOs.Sales
{
    public class CurrentCart
    {
        public int Id { get; set; }
        public int ItemCount => CartItems.Count();
        public IEnumerable<CurrentCartItem> CartItems { get; set; } = [];
    }
    
    public class CurrentCartItem
    {
        public int Quantity { get; set; } = 1;
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal DiscountedPrice { get; set; } = 0;
        public string Thumbnail { get; set; } = null!;
    }
}
