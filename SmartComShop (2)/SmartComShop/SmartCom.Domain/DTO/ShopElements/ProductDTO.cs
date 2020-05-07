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
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Category { get; set; }
    }
}
