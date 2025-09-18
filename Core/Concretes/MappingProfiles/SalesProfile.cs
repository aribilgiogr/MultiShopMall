using AutoMapper;
using Core.Concretes.DTOs.Sales;
using Core.Concretes.Entities.Sales;

namespace Core.Concretes.MappingProfiles
{
    public class SalesProfile : Profile
    {
        public SalesProfile()
        {
            CreateMap<CartItem, CurrentCartItem>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Product.Name))
                .ForMember(d => d.Price, o => o.MapFrom(s => s.Product.Price))
                .ForMember(d => d.DiscountedPrice, o => o.MapFrom(s => s.Product.Price * (100 - s.Product.Discount) / 100))
                .ForMember(d => d.Thumbnail, o => o.MapFrom(s => s.Product.Thumbnail));
            CreateMap<Cart, CurrentCart>();
        }
    }
}
