using Core.Abstracts.IRepositories.Accounts;
using Core.Concretes.Entities.Accounts;
using Data.Contexts;
using Utilities.Generics;

namespace Data.Repositories.Accounts
{
    public class VendorRepository(MallContext context) : Repository<Vendor>(context), IVendorRepository { }
}
