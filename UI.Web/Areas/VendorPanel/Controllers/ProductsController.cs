using Core.Abstracts.IServices;
using Core.Concretes.DTOs.Accounts;
using Core.Concretes.DTOs.Warehouse;
using Core.Concretes.Entities.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using UI.Web.Areas.VendorPanel.Models;

namespace UI.Web.Areas.VendorPanel.Controllers
{
    [Area("VendorPanel")]
    [Authorize(Roles = "Vendor")]
    public class ProductsController(IWarehouseService service) : Controller
    {
        private async Task<int?> getCurrentVendorId()
        {
            // Kullanıcı adı kullanılarak giriş yapıldı mı?
            if (User.Identity != null && User.Identity.Name != null)
            {
                var vendor = await service.GetCurrentVendor(User.Identity.Name);

                // Giriş yapan kullınıcı Market (Vendor) hesabına sahip mi?
                if (vendor != null)
                {
                    return vendor.Id;
                }
            }
            return null;
        }

        // GET: ProductsController
        public async Task<IActionResult> Index()
        {
            var vendorId = await getCurrentVendorId();
            if (vendorId != null)
            {
                return View(await service.GetProductsAsync((int)vendorId));
            }
            return NotFound(); // 404 sayfasına yönlendirilir.
        }



        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductsController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Categories = new SelectList(await service.GetCategoriesAsync(), "Id", "Name");
            ViewBag.SubCategories = new SelectList(await service.GetSubCategoriesAsync(), "Id", "Name");
            ViewBag.Brands = new SelectList(await service.GetBrandsAsync(), "Id", "Name");
            ViewBag.ProductModels = new SelectList(await service.GetModelsAsync(), "Id", "Name");

            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(NewProductViewModel model)
        {
            var vendorId = await getCurrentVendorId();
            if (vendorId != null)
            {
                if (ModelState.IsValid)
                {
                    ViewBag.Categories = new SelectList(await service.GetCategoriesAsync(), "Id", "Name", model.CategoryId);
                    ViewBag.SubCategories = new SelectList(await service.GetSubCategoriesAsync(), "Id", "Name", model.SubCategoryId);
                    ViewBag.Brands = new SelectList(await service.GetBrandsAsync(), "Id", "Name", model.BrandId);
                    ViewBag.ProductModels = new SelectList(await service.GetModelsAsync(), "Id", "Name", model.ProductModelId);




                    return RedirectToAction("index");
                }
                return View(model);
            }
            return NotFound(); // 404 sayfasına yönlendirilir.
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
