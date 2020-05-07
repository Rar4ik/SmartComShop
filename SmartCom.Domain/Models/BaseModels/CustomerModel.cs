using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartCom.Domain.Entities.BaseEntities;

namespace SmartCom.Domain.Models.BaseModels
{
    [Table(name:"Customer")]
    public class CustomerModel : ModelEntity
    {
        //Первичный ключ определяющий запись в таблице

        //Наименование заказчика
        public string CustomerName { get; set; }

        //Код заказчика
        public string CustomerCode { get; set; }

        //Адрес заказчика
        public string CustomerAddress { get; set; }

        //% скидки для заказчика
        public int? CustomerDiscount { get; set; }
    }
}