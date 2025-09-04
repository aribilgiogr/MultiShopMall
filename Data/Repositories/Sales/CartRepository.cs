using Core.Abstracts.IRepositories.Sales;
using Core.Concretes.Entities.Sales;
using Data.Contexts;
using Utilities.Generics;

namespace Data.Repositories.Sales
{
    public class CartRepository(MallContext context) : Repository<Cart>(context), ICartRepository { }
}
