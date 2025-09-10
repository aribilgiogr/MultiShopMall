using Core.Abstracts;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs.Accounts;
using Core.Concretes.Entities.Accounts;
using Microsoft.EntityFrameworkCore;
using Utilities.Models;

namespace Business.Services
{
    public class AccountService(IUnitOfWork unitOfWork) : IAccountService
    {
        public async Task<ResponseModel<string>> ForgotPasswordAsync(string email)
        {
            var user = await unitOfWork.UserManager.FindByEmailAsync(email);
            if (user == null || !await unitOfWork.UserManager.IsEmailConfirmedAsync(user))
            {
                return ResponseModel<string>.Error("Bu eposta adresi kayıtlı değil veya onaylanmamış!");
            }

            var reset_code = await unitOfWork.UserManager.GeneratePasswordResetTokenAsync(user);
            user.ActivationCode = reset_code;
            user.CodeExpireDate = DateTime.UtcNow.AddMinutes(60);
            await unitOfWork.UserManager.UpdateAsync(user);

            //Normal şartlarda burada kullanıcıya reset linki gönderilir.
            return ResponseModel<string>.Success(reset_code);
        }

        public async Task<MemberModel?> GetMemberModel(string username)
        {
            var user = await unitOfWork.UserManager.FindByNameAsync(username);

            if (user == null) return null;

            var roles = await unitOfWork.UserManager.GetRolesAsync(user);

            return new MemberModel
            {
                UserName = user.UserName,
                Email = user.Email,
                Firstname = user.Firstname,
                Middlename = user.Middlename,
                Lastname = user.Lastname,
                Role = roles.FirstOrDefault() ?? "",
                Bio = user.Bio,
                DateOfBirth = user.DateOfBirth,
                EmailConfirmed = user.EmailConfirmed,
                ProfilePicture = user.ProfilePicture,
                Sex = user.Sex
            };
        }

        public async Task<ResponseModel<LoginModel>> LoginAsync(LoginModel model)
        {
            var user = await unitOfWork.UserManager.FindByNameAsync(model.Username);
            if (user == null) return ResponseModel<LoginModel>.Error("Kullanıcı adı bulunamadı!");

            var result = await unitOfWork.SignInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, true);

            if (result.Succeeded) return ResponseModel<LoginModel>.Success(model, "Giriş başarılı");

            if (result.IsLockedOut) return ResponseModel<LoginModel>.Error("Hesap kilitli!");

            if (result.IsNotAllowed) return ResponseModel<LoginModel>.Error("Giriş izni yok!");

            return ResponseModel<LoginModel>.Error("Şifre hatalı!");
        }

        public async Task LogoutAsync()
        {
            await unitOfWork.SignInManager.SignOutAsync();
        }

        public async Task<ResponseModel<string>> RegisterAsync(RegisterModel model)
        {
            var user = new Member
            {
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                UserName = model.Username,
                Email = model.Email,
                EmailConfirmed = false,
            };
            var result = await unitOfWork.UserManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var code = await unitOfWork.UserManager.GenerateEmailConfirmationTokenAsync(user);
                user.ActivationCode = code;
                user.CodeExpireDate = DateTime.UtcNow.AddMinutes(60);
                await unitOfWork.UserManager.UpdateAsync(user);

                return ResponseModel<string>.Success(code, "Kayıt başarılı.");
            }

            var errors = string.Join("; ", result.Errors.Select(x => x.Description));
            return ResponseModel<string>.Error("Kayıt başarısız!", errors);
        }

        public async Task<ResponseModel<string>> ResetPasswordAsync(string code, string oldPassword, string newPassword)
        {
            var user = await unitOfWork.UserManager.Users.FirstOrDefaultAsync(x =>
                x.ActivationCode == code &&
                x.CodeExpireDate != null &&
                x.CodeExpireDate.Value > DateTime.UtcNow
            );

            if (user == null) return ResponseModel<string>.Error("Yanlış veya süresi geçmiş kod!");

            if (!await unitOfWork.UserManager.CheckPasswordAsync(user, oldPassword)) return ResponseModel<string>.Error("Eski şifre hatalı!");

            var result = await unitOfWork.UserManager.ChangePasswordAsync(user, oldPassword, newPassword);

            if (!result.Succeeded) return ResponseModel<string>.Error("Şifre değiştirme başarısız!", string.Join("; ", result.Errors.Select(x => x.Description)));

            user.ActivationCode = null;
            user.CodeExpireDate = null;
            await unitOfWork.UserManager.UpdateAsync(user);
            return ResponseModel<string>.Success("", "Kayıt başarılı.");
        }
    }
}
