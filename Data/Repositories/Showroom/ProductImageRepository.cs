using Core.Abstracts.IRepositories.Showroom;
using Core.Concretes.Entities.Showroom;
using Data.Contexts;
using Utilities.Generics;

namespace Data.Repositories.Showroom
{
    public class ProductImageRepository(MallContext context) : Repository<ProductImage>(context), IProductImageRepository { }
}
