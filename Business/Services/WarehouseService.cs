using Core.Abstracts;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs.Accounts;
using Core.Concretes.DTOs.Warehouse;
using Core.Concretes.Entities.Accounts;
using Core.Concretes.Entities.Showroom;
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

        public async Task AddBrandAsync(string name, string? logo = null)
        {
            await unitOfWork.BrandRepository.CreateAsync(new Brand { Name = name, Logo = logo });
            await unitOfWork.CommitAsync();
        }

        public async Task AddCategoryAsync(string name)
        {
            await unitOfWork.CategoryRepository.CreateAsync(new Category { Name = name });
            await unitOfWork.CommitAsync();
        }

        public Task AddImagesToProductAsync(int productId, string[] images)
        {
            throw new NotImplementedException();
        }

        public async Task AddModelAsync(string name)
        {
            await unitOfWork.ProductModelRepository.CreateAsync(new ProductModel { Name = name });
            await unitOfWork.CommitAsync();
        }

        public Task AddSubCategoryAsync(string name, int parentId)
        {
            throw new NotImplementedException();
        }

        public async Task CreateProductAsync(CreateProduct model)
        {
            var product = new Product
            {
                Name = model.Name,
                Thumbnail = model.Thumbnail,
                Description = model.Description,
                BrandId = model.BrandId,
                SubCategoryId = model.SubCategoryId,
                Price = model.Price,
                Discount = model.Discount,
                VendorId = model.VendorId,
                ProductModelId = model.ProductModelId
            };

            // Bu işlemden sonra product nesnesindeki Id alanı güncellenir, bu sayede aşağıdaki nesnelerde o alanı kullanabilir.
            await unitOfWork.ProductRepository.CreateAsync(product);

            if (model.Images.Any())
            {
                var images = from i in model.Images select new ProductImage { ImagePath = i, ProductId = product.Id };
                await unitOfWork.ProductImageRepository.CreateManyAsync(images);
            }

            if (model.Attributes.Any())
            {
                var attributes = model.Attributes.Select(a => new ProductAttribute { Key = a.Key, Value = a.Value, ProductId = product.Id });
                await unitOfWork.ProductAttributeRepository.CreateManyAsync(attributes);
            }

            await unitOfWork.CommitAsync();
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

        public async Task<VendorModel?> GetCurrentVendor(string username)
        {
            var user = await unitOfWork.UserManager.FindByNameAsync(username);
            if (user != null)
            {
                var vendor = await unitOfWork.VendorRepository.FirstAsync(x => x.MemberId == user.Id);
                if (vendor != null)
                {
                    return new VendorModel
                    {
                        Username = username,
                        StoreName = vendor.StoreName,
                        Id = vendor.Id,
                        Banner = vendor.Banner,
                        Description = vendor.Description,
                        Logo = vendor.Logo
                    };
                }
            }
            return null;
        }

        public async Task<IEnumerable<ModelListItem>> GetModelsAsync()
        {
            var models = await unitOfWork.ProductModelRepository.ReadAsync(x => x.Active && !x.Deleted);
            return models.Select(m => new ModelListItem { Id = m.Id, Name = m.Name });
        }

        public async Task<IEnumerable<ProductListItem>> GetProductsAsync(int vendorId)
        {
            var products = await unitOfWork.ProductRepository.ReadAsync(x => x.VendorId == vendorId, "SubCategory.Category", "Brand", "ProductModel", "Attributes", "Images");
            return from p in products
                   select new ProductListItem
                   {
                       Id = p.Id,
                       Name = p.Name,
                       Price = p.Price,
                       Discount = p.Discount,
                       Thumbnail = p.Thumbnail,
                       BrandName = p.Brand?.Name ?? "",
                       CategoryName = p.SubCategory?.Category?.Name ?? "",
                       ModelName = p.ProductModel?.Name ?? "",
                       SubCategoryName = p.SubCategory?.Name ?? ""
                   };
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

        public async Task RemoveModelAsync(int id)
        {
            var model = await unitOfWork.ProductModelRepository.ReadAsync(id);
            if (model != null)
            {
                model.Deleted = true;
                model.Active = false;
                await unitOfWork.ProductModelRepository.UpdateAsync(model);
                await unitOfWork.CommitAsync();
            }
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
