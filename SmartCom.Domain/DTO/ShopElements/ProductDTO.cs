using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCom.Domain.Entities.BaseEntities;

namespace SmartCom.Domain.DTO.ShopElements
{
    public class ProductDTO : DTOEntity
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
        public string ProductCategory { get; set; }
    }
}
