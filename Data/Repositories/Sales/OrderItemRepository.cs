using Core.Abstracts.IRepositories.Sales;
using Core.Concretes.Entities.Sales;
using Data.Contexts;
using Utilities.Generics;

namespace Data.Repositories.Sales
{
    public class OrderItemRepository(MallContext context) : Repository<OrderItem>(context), IOrderItemRepository
    {
        public async Task CreateManyAsync(IEnumerable<OrderItem> items) => await _set.AddRangeAsync(items);
    }
}
