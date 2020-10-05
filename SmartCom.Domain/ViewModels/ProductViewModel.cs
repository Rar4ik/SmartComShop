using System;

namespace SmartCom.Domain.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
        public string ProductCategory { get; set; }
        public string ProductCode { get; set; }
    }
}