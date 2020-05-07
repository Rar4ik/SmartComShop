
using AutoMapper;
using SmartCom.Domain.DTO.ShopElements;
using SmartCom.Domain.ViewModels;

namespace Services.AutoMapper
{
    public class AutoMapperViewModel : Profile
    {
        public AutoMapperViewModel()
        {
            CreateMap<CustomerDTO, CustomerViewModel>().ReverseMap();
            CreateMap<ProductDTO, ProductViewModel>().ReverseMap();
            CreateMap<OrderElementDTO, OrderElementViewModel>().ReverseMap();
            CreateMap<OrderDTO, OrderViewModel>().ReverseMap();
        }
    }
}
