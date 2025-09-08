using Core.Abstracts;
using Core.Abstracts.IRepositories.Accounts;
using Core.Abstracts.IRepositories.Sales;
using Core.Abstracts.IRepositories.Showroom;
using Core.Concretes.Entities.Accounts;
using Data.Contexts;
using Data.Repositories.Accounts;
using Data.Repositories.Sales;
using Data.Repositories.Showroom;
using Microsoft.AspNetCore.Identity;

namespace Data
{
    public class UnitOfWork(MallContext context, UserManager<Member> userManager, RoleManager<MemberRole> roleManager, SignInManager<Member> signInManager) : IUnitOfWork
    {
        #region Showroom
        private IProductRepository? productRepository;
        public IProductRepository ProductRepository => productRepository ??= new ProductRepository(context);

        private IProductAttributeRepository? productAttributeRepository;
        public IProductAttributeRepository ProductAttributeRepository => productAttributeRepository ??= new ProductAttributeRepository(context);

        private IProductImageRepository? productImageRepository;
        public IProductImageRepository ProductImageRepository => productImageRepository ??= new ProductImageRepository(context);

        private IProductModelRepository? productModelRepository;
        public IProductModelRepository ProductModelRepository => productModelRepository ??= new ProductModelRepository(context);

        private ICategoryRepository? categoryRepository;
        public ICategoryRepository CategoryRepository => categoryRepository ??= new CategoryRepository(context);

        private ISubCategoryRepository? subCategoryRepository;
        public ISubCategoryRepository SubCategoryRepository => subCategoryRepository ??= new SubCategoryRepository(context);

        private IBrandRepository? brandRepository;
        public IBrandRepository BrandRepository => brandRepository ??= new BrandRepository(context);

        #endregion

        #region Sales
        private ICartRepository? cartRepository;
        public ICartRepository CartRepository => cartRepository ??= new CartRepository(context);

        private ICartItemRepository? cartItemRepository;
        public ICartItemRepository CartItemRepository => cartItemRepository ??= new CartItemRepository(context);

        private IOrderRepository? orderRepository;
        public IOrderRepository OrderRepository => orderRepository ??= new OrderRepository(context);

        private IOrderItemRepository? orderItemRepository;
        public IOrderItemRepository OrderItemRepository => orderItemRepository ??= new OrderItemRepository(context);
        #endregion

        #region Accounts
        private ICustomerRepository? customerRepository;
        public ICustomerRepository CustomerRepository => customerRepository ??= new CustomerRepository(context);

        private IVendorRepository? vendorRepository;
        public IVendorRepository VendorRepository => vendorRepository ??= new VendorRepository(context);

        private IAdministratorRepository? administratorRepository;
        public IAdministratorRepository AdministratorRepository => administratorRepository ??= new AdministratorRepository(context);

        public UserManager<Member> UserManager => userManager;
        public RoleManager<MemberRole> RoleManager => roleManager;
        public SignInManager<Member> SignInManager => signInManager;
        #endregion

        public async Task CommitAsync()
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await DisposeAsync();
                string? exception_message = ex.StackTrace;
                throw;
            }
        }

        public async ValueTask DisposeAsync() => await context.DisposeAsync();
    }
}
