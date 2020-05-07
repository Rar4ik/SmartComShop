using System;
using System.ComponentModel.DataAnnotations.Schema;
using SmartCom.Domain.Entities.BaseEntities;

namespace SmartCom.Domain.Models.BaseModels
{
    [Table(name: "Product")]
    public class ProductModel : ModelEntity
    {
        //Код товара
        public string ProductCode { get; set; }

        //Наименование товара
        public string ProductName { get; set; }

        //Цена за единицу
        public decimal? ProductPrice { get; set; }

        //Категория товара
        public string ProductCategory { get; set; }
    }
}