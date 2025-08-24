using AutoMapper;
using OnlineShop.Db.Model;
using WebPetAppShop.Models;

namespace WebPetAppShop.Helpers
{
    // автомаппинг моделей
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Cart, CartViewModel>().ReverseMap();
            CreateMap<CartItem, CartItemViewModel>().ReverseMap();
            CreateMap<UserDeliveryInfo, UserDeliveryInfoViewModel>().ReverseMap();
            CreateMap<Order, OrderViewModel>().ReverseMap();

            //CreateMap<UserDeliveryInfoViewModel, UserDeliveryInfo>()
            //    .ForMember(x => x.Name, opt => opt.MapFrom(u => $"{u.Name} - {u.Adress}"));
        }
    }
}
