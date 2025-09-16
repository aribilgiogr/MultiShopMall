using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Web.Areas.VendorPanel.Controllers
{
    [Area("VendorPanel")]
    [Authorize(Roles = "Vendor")]
    public class HomeController : Controller
    {
        // GET: HomeController
        public IActionResult Index()
        {
            return View();
        }
    }
}
