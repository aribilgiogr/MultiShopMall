using Core.Abstracts.IRepositories.Sales;
using Core.Concretes.Entities.Sales;
using Data.Contexts;
using Utilities.Generics;

namespace Data.Repositories.Sales
{
    public class CartItemRepository(MallContext context) : Repository<CartItem>(context), ICartItemRepository { }
}
