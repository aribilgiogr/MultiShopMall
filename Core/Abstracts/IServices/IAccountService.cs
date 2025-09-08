using Core.Concretes.DTOs.Accounts;
using Utilities.Models;

namespace Core.Abstracts.IServices
{
    public interface IAccountService
    {
        Task<ResponseModel<LoginModel>> LoginAsync(LoginModel model);
        Task LogoutAsync();
        Task<ResponseModel<string>> RegisterAsync(RegisterModel model);
        Task<ResponseModel<string>> ForgotPasswordAsync(string email);
        Task<ResponseModel<string>> ResetPasswordAsync(string code, string oldPassword, string newPassword);
    }
}
