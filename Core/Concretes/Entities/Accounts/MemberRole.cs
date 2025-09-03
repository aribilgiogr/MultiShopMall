using Microsoft.AspNetCore.Identity;

namespace Core.Concretes.Entities.Accounts
{
    public class MemberRole : IdentityRole
    {
        public string? Description { get; set; }
    }
}
