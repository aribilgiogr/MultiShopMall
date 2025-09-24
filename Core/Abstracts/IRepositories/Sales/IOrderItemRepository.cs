using Core.Concretes.Entities.Sales;
using Core.Concretes.Entities.Showroom;
using Utilities.Generics;

namespace Core.Abstracts.IRepositories.Sales
{
    public interface IOrderItemRepository : IRepository<OrderItem> {
        Task CreateManyAsync(IEnumerable<OrderItem> items);
    }
}
