using Core.Concretes.DTOs.Sales;

namespace Core.Abstracts.IServices
{
    public interface ISalesService
    {
        Task<CurrentCart> GetCurrentCartAsync(string username);
        Task AddToCartAsync(string username, int productId, int qty = 1);
        Task RemoveFromCartAsync(string username, int productId);
        Task ChangeQuantityAsync(string username, int productId, int qty = 0);
        Task<int> CheckOutAsync(string username);
    }
}
