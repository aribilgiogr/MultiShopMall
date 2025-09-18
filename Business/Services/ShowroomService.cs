using AutoMapper;
using Core.Abstracts;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs.Warehouse;
using Core.Concretes.Models;

namespace Business.Services
{
    public class ShowroomService(IUnitOfWork unitOfWork, IMapper mapper) : IShowroomService
    {
        public async Task<IEnumerable<BrandListItem>> GetBrandsAsync()
        {
            var brands = await unitOfWork.BrandRepository.ReadAsync(x => x.Active && !x.Deleted);
            return mapper.Map<IEnumerable<BrandListItem>>(brands);
        }

        public async Task<IEnumerable<SubCategoryListItem>> GetCategoriesAsync()
        {
            var subcategories = await unitOfWork.SubCategoryRepository.ReadAsync(x => x.Active && !x.Deleted, "Category");
            return mapper.Map<IEnumerable<SubCategoryListItem>>(subcategories);
        }

        public Task<IEnumerable<ProductDetail>> GetProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ModelListItem>> GetProductModelsAsync()
        {
            var models = await unitOfWork.ProductModelRepository.ReadAsync(x => x.Active && !x.Deleted);
            return mapper.Map<IEnumerable<ModelListItem>>(models);
        }

        public async Task<IEnumerable<ProductListItem>> GetProductsAsync(ProductsFilter? filter = null)
        {
            var products = await unitOfWork.ProductRepository.ReadAsync(x => x.Active && !x.Deleted, "SubCategory.Category", "Brand", "ProductModel");
            return mapper.Map<IEnumerable<ProductListItem>>(products);
        }
    }
}
