using Core.Abstracts.IRepositories.Accounts;
using Core.Abstracts.IRepositories.Sales;
using Core.Abstracts.IRepositories.Showroom;
using Core.Concretes.Entities.Accounts;
using Microsoft.AspNetCore.Identity;

namespace Core.Abstracts
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        #region Showroom
        IProductRepository ProductRepository { get; }
        IProductAttributeRepository ProductAttributeRepository { get; }
        IProductImageRepository ProductImageRepository { get; }
        IProductModelRepository ProductModelRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ISubCategoryRepository SubCategoryRepository { get; }
        IBrandRepository BrandRepository { get; }
        #endregion

        #region Sales
        ICartRepository CartRepository { get; }
        ICartItemRepository CartItemRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderItemRepository OrderItemRepository { get; }
        #endregion

        #region Accounts
        ICustomerRepository CustomerRepository { get; }
        IVendorRepository VendorRepository { get; }
        IAdministratorRepository AdministratorRepository { get; }
        UserManager<Member> UserManager { get; }
        RoleManager<MemberRole> RoleManager { get; }
        SignInManager<Member> SignInManager { get; }
        #endregion

        Task CommitAsync();
    }
}
