using Core.Abstracts.IRepositories.Showroom;
using Core.Concretes.Entities.Showroom;
using Data.Contexts;
using Utilities.Generics;

namespace Data.Repositories.Showroom
{
    public class BrandRepository(MallContext context) : Repository<Brand>(context), IBrandRepository { }
}
