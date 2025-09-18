using Core.Concretes.DTOs.Warehouse;

namespace UI.Web.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<SubCategoryListItem> Categories { get; set; } = [];
        public IEnumerable<BrandListItem> Brands { get; set; } = [];
        public IEnumerable<ModelListItem> ProductModels { get; set; } = [];
        public IEnumerable<ProductListItem> Products { get; set; } = [];
    }
}
