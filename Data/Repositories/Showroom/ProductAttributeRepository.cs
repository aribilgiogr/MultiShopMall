using Core.Abstracts.IRepositories.Showroom;
using Core.Concretes.Entities.Showroom;
using Data.Contexts;
using Utilities.Generics;

namespace Data.Repositories.Showroom
{
    public class ProductAttributeRepository(MallContext context) : Repository<ProductAttribute>(context), IProductAttributeRepository
    {
        public async Task CreateManyAsync(IEnumerable<ProductAttribute> attributes) => await _set.AddRangeAsync(attributes);
    }
}
