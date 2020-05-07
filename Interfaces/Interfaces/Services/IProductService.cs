using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SmartCom.Domain.DTO.ShopElements;

namespace Interfaces.Services
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetProducts();
        string GetProductCode();
        string GetProduct();
        string GetProductCategory();
        decimal GetProductPrice();
    }
}
