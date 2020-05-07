using System.Collections.Generic;
using SmartCom.Domain.DTO.ShopElements;

namespace SmartCom.Domain.ViewModels
{
    public class OrderElementViewModel
    {
        public IEnumerable<ProductDTO> ListOfProductDtos { get; set; }
        public int OrderElements { get; set; }
        public int OrderElemetPrice { get; set; }
    }
}