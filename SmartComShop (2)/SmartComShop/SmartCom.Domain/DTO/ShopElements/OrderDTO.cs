using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCom.Domain.Entities.BaseEntities;
using SmartCom.Domain.Models.BaseModels;

namespace SmartCom.Domain.DTO.ShopElements
{
    public class OrderDTO : DTOEntity
    {
        public Guid CustomerId { get; set; }
        public virtual CustomerModel Customer { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime DateDelivered { get; set; }
        public int? Number { get; set; }
        public string Status { get; set; }
    }
}
