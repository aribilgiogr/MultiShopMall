using Core.Abstracts.IRepositories.Accounts;
using Core.Concretes.Entities.Accounts;
using Data.Contexts;
using Utilities.Generics;

namespace Data.Repositories.Accounts
{
    public class AdministratorRepository(MallContext context) : Repository<Administrator>(context), IAdministratorRepository { }
}
