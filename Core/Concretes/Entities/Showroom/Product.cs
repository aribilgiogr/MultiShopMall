using Core.Abstracts.Bases;
using Core.Concretes.Entities.Accounts;
using Core.Concretes.Entities.Sales;

namespace Core.Concretes.Entities.Showroom
{
    public class Product : BaseEntity
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int SubCategoryId { get; set; }
        public virtual SubCategory? SubCategory { get; set; }
        public int BrandId { get; set; }
        public virtual Brand? Brand { get; set; }
        public int ProductModelId { get; set; }
        public virtual ProductModel? ProductModel { get; set; }
        public required string Thumbnail { get; set; }
        public virtual ICollection<ProductAttribute> Attributes { get; set; } = [];
        public virtual ICollection<ProductImage> Images { get; set; } = [];
        public virtual ICollection<CartItem> CartItems { get; set; } = [];
        public virtual ICollection<OrderItem> OrderItems { get; set; } = [];
        public int VendorId { get; set; }
        public virtual Vendor? Vendor { get; set; }
    }
}
