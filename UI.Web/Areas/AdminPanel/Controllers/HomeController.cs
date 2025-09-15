using Core.Abstracts.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
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

        [HttpPost]
        public async Task<IActionResult> CreateCategory(string name)
        {
            await service.AddCategoryAsync(name);
            return RedirectToAction("index");
        }

        [HttpPost]
        public async Task<IActionResult> CreateModel(string name)
        {
            await service.AddModelAsync(name);
            return RedirectToAction("index");
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(string name, IFormFile? logo)
        {
            string? logoPath = null;
            if (logo != null && logo.Length > 0)
            {
                var uploadsDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "brands");
                Directory.CreateDirectory(uploadsDir);

                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(logo.FileName)}";
                var filePath = Path.Combine(uploadsDir, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await logo.CopyToAsync(stream);
                }

                logoPath = $"/uploads/brands/{fileName}";
            }
            await service.AddBrandAsync(name, logoPath);
            return RedirectToAction("index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveModel(int id)
        {
            await service.RemoveModelAsync(id);
            return RedirectToAction("index");
        }
    }
}
