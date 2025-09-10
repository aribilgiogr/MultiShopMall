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
}
