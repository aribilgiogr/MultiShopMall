using Core.Abstracts.IServices;
using Core.Concretes.DTOs.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Utilities.Constants;

namespace UI.Web.Controllers
{
    public class AccountController(IAccountService service) : Controller
    {
        // Profil veya ayarlar sayfası gibi bir sayfa için örnek action
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await service.GetMemberModel(User.Identity.Name));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl = "/")
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await service.LoginAsync(model);

            if (result.Tag != ResponseTag.INFO)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                ModelState.AddModelError(string.Empty, result.Detail);
                return View(model);
            }

            return Redirect(returnUrl);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await service.RegisterAsync(model);
            if (result.Tag != ResponseTag.INFO)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                ModelState.AddModelError(string.Empty, result.Detail);
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        public Task<IActionResult> ForgotPassword()
        {
            return Task.FromResult<IActionResult>(View());
        }

        public Task<IActionResult> ResetPassword(string code, string email)
        {
            ViewBag.Code = code;
            ViewBag.Email = email;
            return Task.FromResult<IActionResult>(View());
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await service.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
