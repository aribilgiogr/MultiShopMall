using Core.Abstracts.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UI.Web.Models;

namespace UI.Web.Controllers
{
    public class HomeController(IShowroomService service, ISalesService salesService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var model = new ProductListViewModel()
            {
                Categories = await service.GetCategoriesAsync(),
                Brands = await service.GetBrandsAsync(),
                ProductModels = await service.GetProductModelsAsync(),
                Products = await service.GetProductsAsync(),
            };
            return View(model);
        }

        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> ShoppingCart()
        {
            var model = await salesService.GetCurrentCartAsync(User.Identity.Name);
            return View(model.CartItems);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
