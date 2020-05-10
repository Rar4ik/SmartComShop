using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SmartCom.Domain.DTO.ShopElements;
using SmartCom.Domain.ViewModels;

namespace Interfaces.Services
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetProducts();
        ProductDTO GetProduct(Guid id);
        void AddProduct(ProductDTO product);
        void Edit(Guid id, ProductDTO product);
        void Delete(ProductDTO product);
    }
}
