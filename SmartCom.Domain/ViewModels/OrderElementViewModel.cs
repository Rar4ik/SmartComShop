using System.Collections.Generic;
using SmartCom.Domain.DTO.ShopElements;

namespace SmartCom.Domain.ViewModels
{
    public class OrderElementViewModel
    {
        public IEnumerable<ProductDTO> Product { get; set; }
        public int OrderElementAmount { get; set; }
        public int OrderElementPrice { get; set; }
    }
}