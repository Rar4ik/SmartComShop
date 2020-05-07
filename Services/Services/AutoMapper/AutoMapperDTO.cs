using AutoMapper;
using SmartCom.Domain.DTO.ShopElements;
using SmartCom.Domain.Models.BaseModels;

namespace Services.AutoMapper
{
    public class AutoMapperDTO : Profile
    {
        public AutoMapperDTO()
        {
            CreateMap<CustomerModel, CustomerDTO>().ReverseMap()
                .ForMember("CustomerName", opt => opt.MapFrom(c => c.CustomerName))
                .ForMember("CustomerCode", opt => opt.MapFrom(c => c.Code))
                .ForMember("CustomerAddress", opt => opt.MapFrom(c => c.CustomerAddress))
                .ForMember("CustomerDiscount", opt => opt.MapFrom(c => c.CustomerDiscount));
            CreateMap<ProductModel, ProductDTO>().ReverseMap()
                .ForMember("ProductCode", opt => opt.MapFrom(c => c.ProductCode))
                .ForMember("ProductName", opt => opt.MapFrom(c => c.ProductName))
                .ForMember("ProductPrice", opt => opt.MapFrom(c => c.ProductPrice))
                .ForMember("ProductCategory", opt => opt.MapFrom(c => c.ProductCategory)); 
            CreateMap<OrderElementModel, OrderElementDTO>().ReverseMap()
                .ForMember("Order", opt => opt.MapFrom(c => c.Order))
                .ForMember("Product", opt => opt.MapFrom(c => c.Product))
                .ForMember("OrderElementPrice", opt => opt.MapFrom(c => c.OrderElementPrice))
                .ForMember("OrderElementAmount", opt => opt.MapFrom(c => c.OrderElementAmount))
                .ForMember("OrderId", opt => opt.MapFrom(c => c.OrderId))
                .ForMember("ProductId", opt => opt.MapFrom(c => c.ProductId));
            CreateMap<OrderModel, OrderDTO>().ReverseMap()
                .ForMember("CustomerId", opt => opt.MapFrom(c => c.CustomerId))
                .ForMember("Customer", opt => opt.MapFrom(c => c.Customer))
                .ForMember("OrderDateRequested", opt => opt.MapFrom(c => c.OrderDateRequested))
                .ForMember("OrderDateDelivered", opt => opt.MapFrom(c => c.OrderDateDelivered))
                .ForMember("OrderNumber", opt => opt.MapFrom(c => c.OrderNumber))
                .ForMember("OrderStatus", opt => opt.MapFrom(c => c.OrderStatus)); 
        }
    }
}
