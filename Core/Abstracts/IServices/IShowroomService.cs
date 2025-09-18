using Core.Concretes.DTOs.Warehouse;
using Core.Concretes.Models;

namespace Core.Abstracts.IServices
{
    public interface IShowroomService
    {
        Task<IEnumerable<SubCategoryListItem>> GetCategoriesAsync();
        Task<IEnumerable<BrandListItem>> GetBrandsAsync();
        Task<IEnumerable<ModelListItem>> GetProductModelsAsync();
        Task<IEnumerable<ProductListItem>> GetProductsAsync(ProductsFilter? filter = null);
        Task<IEnumerable<ProductDetail>> GetProductAsync(int id);
    }
}
