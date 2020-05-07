using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartCom.Domain.Entities.BaseEntities;

namespace SmartCom.Domain.Models.BaseModels
{
    [Table(name:"Order")]
    public class OrderModel : ModelEntity
    {
        //Первичный ключ определяющий запись в таблице

        //ID заказчика
        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        public virtual CustomerModel Customer { get; set; }

        //Дата когда сделан заказ
        public DateTime OrderDateRequested { get; set; }

        //Дата доставки заказа
        public DateTime OrderDateDelivered { get; set; }

        //Номер заказа
        public int? OrderNumber { get; set; }

        //Состояние заказа
        public string OrderStatus { get; set; }
    }
}