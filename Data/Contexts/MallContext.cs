using Core.Concretes.Entities.Accounts;
using Core.Concretes.Entities.Sales;
using Core.Concretes.Entities.Showroom;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts
{
    public class MallContext : IdentityDbContext<Member, MemberRole, string>
    {
        public MallContext(DbContextOptions<MallContext> options) : base(options)
        {
        }

        protected MallContext()
        {
        }

        #region Accounts

        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }

        #endregion


        #region Showroom

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<ProductModel> ProductModels { get; set; }
        public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }

        #endregion


        #region Sales

        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }

        #endregion
    }
}
