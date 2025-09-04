using Core.Abstracts.IRepositories.Sales;
using Core.Concretes.Entities.Sales;
using Data.Contexts;
using Utilities.Generics;

namespace Data.Repositories.Sales
{
    public class OrderRepository(MallContext context) : Repository<Order>(context), IOrderRepository { }
}
