using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Web.Controllers
{
    public class AccountsController : Controller
    {
        // Profil veya ayarlar sayfası gibi bir sayfa için örnek action
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public Task<IActionResult> Login()
        {
            return Task.FromResult<IActionResult>(View());
        }

        public Task<IActionResult> Register()
        {
            return Task.FromResult<IActionResult>(View());
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
        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
