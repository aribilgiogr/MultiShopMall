using AutoMapper;
using Core.Abstracts;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs.Sales;
using Core.Concretes.Entities.Sales;
using System.Threading.Tasks;

namespace Business.Services
{
    public class SalesService(IUnitOfWork unitOfWork, IMapper mapper) : ISalesService
    {
        private async Task<Cart> getCart(string username)
        {
            var user = await unitOfWork.UserManager.FindByNameAsync(username);
            if (user != null)
            {
                var customer = await unitOfWork.CustomerRepository.FirstAsync(x => x.MemberId == user.Id);
                if (customer != null)
                {
                    var cart = await unitOfWork.CartRepository.FirstAsync(x => x.Active && !x.Deleted && x.CustomerId == customer.Id, "CartItems.Product");
                    if (cart == null)
                    {
                        cart = new Cart { CustomerId = customer.Id };
                        await unitOfWork.CartRepository.CreateAsync(cart);
                        await unitOfWork.CommitAsync();
                    }
                    return cart;
                }
            }
            throw new KeyNotFoundException();
        }

        public async Task AddToCartAsync(string username, int productId, int qty = 1)
        {
            var cart = await getCart(username);
            var item = await unitOfWork.CartItemRepository.FirstAsync(x => x.CartId == cart.Id && x.ProductId == productId);
            if (item == null)
            {
                item = new CartItem { CartId = cart.Id, ProductId = productId, Quantity = qty };
                await unitOfWork.CartItemRepository.CreateAsync(item);
            }
            else
            {
                item.Quantity += qty;
                await unitOfWork.CartItemRepository.UpdateAsync(item);
            }
            await unitOfWork.CommitAsync();
        }

        public async Task ChangeQuantityAsync(string username, int productId, int qty = 0)
        {
            var cart = await getCart(username);
            var item = await unitOfWork.CartItemRepository.FirstAsync(x => x.ProductId == productId && x.CartId == cart.Id);
            if (item != null)
            {
                item.Quantity += qty;
                if (item.Quantity > 0 && item.Quantity < 10)
                {
                    await unitOfWork.CartItemRepository.UpdateAsync(item);
                    await unitOfWork.CommitAsync();
                }
            }
        }

        public async Task<CurrentCart> GetCurrentCartAsync(string username) => mapper.Map<CurrentCart>(await getCart(username));

        public async Task RemoveFromCartAsync(string username, int productId)
        {
            var cart = await getCart(username);
            var item = await unitOfWork.CartItemRepository.FirstAsync(x => x.ProductId == productId && x.CartId == cart.Id);
            if (item != null)
            {
                await unitOfWork.CartItemRepository.DeleteAsync(item);
                await unitOfWork.CommitAsync();
            }
        }

        public async Task<int> CheckOutAsync(string username)
        {
            var cart = await getCart(username);
            var order = new Order
            {
                CustomerId = cart.CustomerId,
                ItemCount = cart.CartItems.Count,
                TotalDiscount = cart.CartItems.Sum(x => (x.Product.Price * x.Product.Discount / 100) * x.Quantity),
                TotalDue = cart.CartItems.Sum(x => x.Product.Price * x.Quantity)
            };

            await unitOfWork.OrderRepository.CreateAsync(order);
            await unitOfWork.CommitAsync();

            var items = from x in cart.CartItems
                        select new OrderItem
                        {
                            Discount = x.Product.Discount,
                            ListPrice = x.Product.Price,
                            ProductId = x.ProductId,
                            OrderId = order.Id,
                            Quantity = x.Quantity
                        };

            await unitOfWork.OrderItemRepository.CreateManyAsync(items);

            cart.Active = false;

            await unitOfWork.CartRepository.UpdateAsync(cart);

            await unitOfWork.CommitAsync();

            return order.Id;
        }
    }
}
