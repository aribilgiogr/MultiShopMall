using Core.Concretes.Enums;

namespace Core.Concretes.DTOs.Accounts
{
    public class MemberModel
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Firstname { get; set; }
        public string? Middlename { get; set; }
        public required string Lastname { get; set; }
        public string? Bio { get; set; }
        public string? ProfilePicture { get; set; }
        public DateTime? DateOfBirth { get; set; } = null;
        public Gender Sex { get; set; } = Gender.Unknown;
        public required string Role { get; set; }
        public bool EmailConfirmed { get; set; }
    }
}
