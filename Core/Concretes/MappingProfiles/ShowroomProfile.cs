using AutoMapper;
using Core.Concretes.DTOs.Warehouse;
using Core.Concretes.Entities.Showroom;

namespace Core.Concretes.MappingProfiles
{
    public class ShowroomProfile : Profile
    {
        public ShowroomProfile()
        {
            CreateMap<Brand, BrandListItem>();
            CreateMap<Category, CategoryListItem>();
            CreateMap<ProductModel, ModelListItem>();
            CreateMap<Product, ProductListItem>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.SubCategory.Category.Name))
                .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory.Name))
                .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.ProductModel.Name));
            CreateMap<SubCategory, SubCategoryListItem>()
                .ForMember(dest => dest.ParentCategory, opt => opt.MapFrom(src => src.Category));
        }
    }
}
