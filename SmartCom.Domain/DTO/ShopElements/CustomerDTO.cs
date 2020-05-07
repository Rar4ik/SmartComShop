using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCom.Domain.Entities.BaseEntities;

namespace SmartCom.Domain.DTO.ShopElements
{
    public class CustomerDTO : DTOEntity
    {
        public string CustomerName { get; set; }
        public string Code { get; set; }
        public string CustomerAddress { get; set; }
        public int? CustomerDiscount { get; set; }
    }
}
