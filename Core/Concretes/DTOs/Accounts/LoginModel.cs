using Core.Resources;
using System.ComponentModel.DataAnnotations;

namespace Core.Concretes.DTOs.Accounts
{
    public class LoginModel
    {
        [Required, Display(Name = "Username", Prompt = "EnterUsername", ResourceType =typeof(SharedResource))]
        public required string Username { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "Password", Prompt = "EnterPassword", ResourceType = typeof(SharedResource))]
        public required string Password { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(SharedResource))]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        public required string Firstname { get; set; }

        [Required]
        public required string Lastname { get; set; }

        [Required]
        public required string Username { get; set; }

        [Required, EmailAddress]
        public required string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public required string Password { get; set; }

        [Required, DataType(DataType.Password), Compare("Password")]
        public required string PasswordConfirm { get; set; }
    }
}
