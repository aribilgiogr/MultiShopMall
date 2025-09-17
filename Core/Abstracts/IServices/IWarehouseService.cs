using Core.Concretes.DTOs.Accounts;
using Core.Concretes.DTOs.Warehouse;

namespace Core.Abstracts.IServices
{
    public interface IWarehouseService
    {
        #region Vendor Section
        Task<VendorModel?> GetCurrentVendor(string username);
        Task<IEnumerable<ProductListItem>> GetProductsAsync(int vendorId);
        Task<ProductDetail> GetProductAsync(int productId);
        Task CreateProductAsync(CreateProduct model);
        Task DeleteProductAsync(int id);
        Task UpdateProductAsync(EditProduct model);
        Task AddImagesToProductAsync(int productId, string[] images);
        Task RemoveImageFromProductAsync(int productId, int imageId);
        Task AddAttributesToProductAsync(int productId, Dictionary<string, string> attributes);
        Task RemoveAttributeFromProductAsync(int productId, int attributeId);
        #endregion

        #region Administration Section
        Task AddCategoryAsync(string name);
        Task EditCategoryAsync(int id, string name);
        Task RemoveCategoryAsync(int id);
        Task<IEnumerable<CategoryListItem>> GetCategoriesAsync();

        Task AddSubCategoryAsync(string name, int parentId);
        Task EditSubCategoryAsync(int id, string name);
        Task RemoveSubCategoryAsync(int id);
        Task<IEnumerable<SubCategoryListItem>> GetSubCategoriesAsync();

        Task AddBrandAsync(string name, string? logo = null);
        Task EditBrandAsync(int id, string name, string? logo = null);
        Task RemoveBrandAsync(int id);
        Task<IEnumerable<BrandListItem>> GetBrandsAsync();

        Task AddModelAsync(string name);
        Task EditModelAsync(int id, string name);
        Task RemoveModelAsync(int id);
        Task<IEnumerable<ModelListItem>> GetModelsAsync();
        #endregion
    }
}
