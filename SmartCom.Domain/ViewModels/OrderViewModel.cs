using System;
using SmartCom.Domain.DTO.ShopElements;

namespace SmartCom.Domain.ViewModels
{
    public class OrderViewModel
    {
        public CustomerDTO Customer { get; set; }
        public DateTime OrderDateRequested { get; set; }
        public DateTime OrderDateDelivered { get; set; }
        public int? OrderNumber { get; set; }
        public string OrderStatus { get; set; }
    }
}