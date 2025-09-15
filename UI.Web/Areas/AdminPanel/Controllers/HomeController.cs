using Core.Abstracts.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UI.Web.Areas.AdminPanel.Models;

namespace UI.Web.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = "Administrator")]
    public class HomeController(IWarehouseService service) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var model = new HomeIndexViewModel
            {
                Categories = await service.GetCategoriesAsync(),
                Brands = await service.GetBrandsAsync(),
                ProductModels = await service.GetModelsAsync(),
                SubCategories = await service.GetSubCategoriesAsync()
            };
            return View(model);
        }
    }
}
