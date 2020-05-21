
using AutoMapper;
using SmartCom.Domain.DTO.Identity;
using SmartCom.Domain.DTO.ShopElements;
using SmartCom.Domain.ViewModels;

namespace Services.AutoMapper
{
    public class AutoMapperViewModel : Profile
    {
        public AutoMapperViewModel()
        {
            CreateMap<CustomerDTO, UserCustomerViewModel>().ReverseMap();
            CreateMap<ProductDTO, ProductViewModel>().ReverseMap();
            CreateMap<OrderElementDTO, OrderElementViewModel>().ReverseMap();
            CreateMap<OrderDTO, OrderViewModel>().ReverseMap();
            CreateMap<CustomerDTO, UserCustomerViewModel>().ReverseMap()
                .ForMember("CustomerName", c => c.MapFrom(r => r.CustomerName))
                .ForMember("Code", c => c.MapFrom(r => r.Code))
                .ForMember("CustomerAddress", c => c.MapFrom(r => r.CustomerAddress))
                .ForMember("CustomerDiscount", c => c.MapFrom(r => r.CustomerDiscount));
            CreateMap<UserDTO, UserCustomerViewModel>().ReverseMap()
                .ForMember("Email", c => c.MapFrom(r => r.Email))
                .ForMember("PhoneNumber", c => c.MapFrom(r => r.PhoneNumber))
                .ForMember("Password", c => c.MapFrom(r => r.Password))
                .ForMember("UserName", c => c.MapFrom(r => r.UserName));
        }
    }
}
