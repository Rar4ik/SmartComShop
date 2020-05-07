using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartCom.Domain.Entities.BaseEntities;
using SmartCom.Domain.Models.BaseModels;

namespace SmartCom.Domain.Models.BaseModels
{
    [Table(name: "OrderElement")]
    public class OrderElementModel : ModelEntity
    {
        //ИД заказа
        [ForeignKey(name: "Order")]
        public Guid OrderId { get; set; }
        public virtual OrderModel Order { get; set; }

        //ИД товара
        [ForeignKey(name: "Product")]
        public Guid ProductId { get; set; }
        public virtual ICollection<ProductModel> Product { get; set; }

        //Количество заказанного товара
        public int OrderElementAmount { get; set; }

        //Цена за единицу
        public decimal OrderElementPrice { get; set; }
    }
}