using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Web.Areas.Customers.Controllers
{
    [Area("Customers")]
    [Authorize(Roles = "Customer")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
