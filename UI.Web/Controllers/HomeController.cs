using Core.Abstracts.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using UI.Web.Models;

namespace UI.Web.Controllers
{
    public class HomeController(IShowroomService service, ISalesService salesService, IHttpClientFactory factory) : Controller
    {
        private readonly HttpClient client = factory.CreateClient("payment");
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

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public async Task<IActionResult> CheckOut(decimal amount, string paymentType)
        {
            int orderId = await salesService.CheckOutAsync(User.Identity.Name);
            var requestBody = JsonConvert.SerializeObject(new PaymentRequest
            {
                Provider = paymentType,
                Amount = amount,
                Currency = "USD",
                OrderId = orderId.ToString()
            });
            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            var raw_response = await client.PostAsync("process", content);
            var response_text = await raw_response.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<PaymentResponse>(response_text);

            if (response.Success)
            {
                // Siparişi tamamla ve teşekkürler sayfasına git
            }
            else
            {
                // Sipariş durumunu değiştirme, başarısız sayfasına git, 
            }

            return RedirectToAction("ShoppingCart");
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
