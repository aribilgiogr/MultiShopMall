using Core.Abstracts;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs.Warehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class WarehouseService(IUnitOfWork unitOfWork) : IWarehouseService
    {
        public Task AddAttributesToProductAsync(int productId, Dictionary<string, string> attributes)
        {
            throw new NotImplementedException();
        }

        public Task AddBrandAsync(string name, string? logo = null)
        {
            throw new NotImplementedException();
        }

        public Task AddCategoryAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task AddImagesToProductAsync(int productId, string[] images)
        {
            throw new NotImplementedException();
        }

        public Task AddModelAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task AddSubCategoryAsync(string name, int parentId)
        {
            throw new NotImplementedException();
        }

        public Task CreateProductAsync(CreateProduct model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditBrandAsync(int id, string name, string? logo = null)
        {
            throw new NotImplementedException();
        }

        public Task EditCategoryAsync(int id, string name)
        {
            throw new NotImplementedException();
        }

        public Task EditModelAsync(int id, string name)
        {
            throw new NotImplementedException();
        }

        public Task EditSubCategoryAsync(int id, string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BrandListItem>> GetBrandsAsync()
        {
            var brands = await unitOfWork.BrandRepository.ReadAsync(x => x.Active && !x.Deleted);
            return from b in brands
                   select new BrandListItem { Id = b.Id, Name = b.Name, Logo = b.Logo };
        }

        public async Task<IEnumerable<CategoryListItem>> GetCategoriesAsync()
        {
            var categories = await unitOfWork.CategoryRepository.ReadAsync(x => x.Active && !x.Deleted);
            return from c in categories select new CategoryListItem { Id = c.Id, Name = c.Name };
        }

        public async Task<IEnumerable<ModelListItem>> GetModelsAsync()
        {
            var models = await unitOfWork.ProductModelRepository.ReadAsync(x => x.Active && !x.Deleted);
            return models.Select(m => new ModelListItem { Id = m.Id, Name = m.Name });
        }

        public Task<IEnumerable<ProductListItem>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SubCategoryListItem>> GetSubCategoriesAsync()
        {
            var subcategories = await unitOfWork.SubCategoryRepository.ReadAsync(x => x.Active && !x.Deleted, "Category");
            return subcategories.Select(sc => new SubCategoryListItem
            {
                Id = sc.Id,
                Name = sc.Name,
                ParentCategory = new CategoryListItem { Id = sc.CategoryId, Name = sc.Category.Name }
            });
        }

        public Task RemoveAttributeFromProductAsync(int productId, int attributeId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveBrandAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveImageFromProductAsync(int productId, int imageId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveModelAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveSubCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsync(EditProduct model)
        {
            throw new NotImplementedException();
        }
    }
}
