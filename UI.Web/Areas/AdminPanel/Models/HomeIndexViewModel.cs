using Core.Concretes.DTOs.Warehouse;

namespace UI.Web.Areas.AdminPanel.Models
{
    public class HomeIndexViewModel
    {
        public IEnumerable<CategoryListItem> Categories { get; set; } = [];
        public IEnumerable<SubCategoryListItem> SubCategories { get; set; } = [];
        public IEnumerable<BrandListItem> Brands { get; set; } = [];
        public IEnumerable<ModelListItem> ProductModels { get; set; } = [];
    }
}
