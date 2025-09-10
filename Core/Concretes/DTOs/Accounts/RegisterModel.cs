using Core.Resources;
using System.ComponentModel.DataAnnotations;

namespace Core.Concretes.DTOs.Accounts
{
    public class RegisterModel
    {
        [Required, Display(Name = "Firstname", Prompt = "Firstname", ResourceType = typeof(SharedResource))]
        public required string Firstname { get; set; }

        [Required, Display(Name = "Lastname", Prompt = "Lastname", ResourceType = typeof(SharedResource))]
        public required string Lastname { get; set; }

        [Required, Display(Name = "Username", Prompt = "EnterUsername", ResourceType = typeof(SharedResource))]
        public required string Username { get; set; }

        [Required, EmailAddress, Display(Name = "Email", Prompt = "EnterEmail", ResourceType = typeof(SharedResource))]
        public required string Email { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "Password", Prompt = "EnterPassword", ResourceType = typeof(SharedResource))]
        public required string Password { get; set; }

        [Required, DataType(DataType.Password), Compare("Password"), Display(Name = "PasswordConfirm", Prompt = "EnterPasswordConfirm", ResourceType = typeof(SharedResource))]
        public required string PasswordConfirm { get; set; }
    }
}
