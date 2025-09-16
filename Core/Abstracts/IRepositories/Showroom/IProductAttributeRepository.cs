using Core.Concretes.Entities.Showroom;
using Utilities.Generics;

namespace Core.Abstracts.IRepositories.Showroom
{
    public interface IProductAttributeRepository : IRepository<ProductAttribute>
    {
        Task CreateManyAsync(IEnumerable<ProductAttribute> attributes);
    }
}
