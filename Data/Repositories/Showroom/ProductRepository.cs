using Core.Abstracts.IRepositories.Showroom;
using Core.Concretes.Entities.Showroom;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Generics;

namespace Data.Repositories.Showroom
{
    public class ProductRepository(MallContext context) : Repository<Product>(context), IProductRepository { }
}
