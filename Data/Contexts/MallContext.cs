using Core.Concretes.Entities.Accounts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts
{
    public class MallContext : IdentityDbContext<Member, MemberRole, string>
    {
        public MallContext(DbContextOptions<MallContext> options) : base(options)
        {
        }

        protected MallContext()
        {
        }
    }
}
