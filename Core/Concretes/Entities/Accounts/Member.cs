using Core.Concretes.Enums;
using Microsoft.AspNetCore.Identity;

namespace Core.Concretes.Entities.Accounts
{
    public class Member : IdentityUser
    {
        public required string Firstname { get; set; }
        public string? Middlename { get; set; }
        public required string Lastname { get; set; }
        public string? Bio { get; set; }
        public string? ProfilePicture { get; set; }
        public DateTime? DateOfBirth { get; set; } = null;
        public Gender Sex { get; set; } = Gender.Unknown;
        public string? ActivationCode { get; set; }
        public DateTime? CodeExpireDate { get; set; }
    }
}
