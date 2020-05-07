using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCom.Domain.Entities.BaseEntities;
using SmartCom.Domain.Models.BaseModels;

namespace SmartCom.Domain.DTO.ShopElements
{
    public class OrderElementDTO : DTOEntity
    {
        public Guid OrderId { get; set; }
        public virtual OrderModel Order { get; set; }
        public Guid ProductId { get; set; }
        public virtual ICollection<ProductModel> Product { get; set; }
        public int OrderElementAmount { get; set; }
        public decimal OrderElementPrice { get; set; }
    }
}
