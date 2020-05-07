using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCom.Domain.DTO.ShopElements;

namespace Interfaces.Services
{
    public interface IOrderElementService
    {
        IEnumerable<ProductDTO> GetProducts();
        OrderDTO Order();
        int OrderElementAmount();
        decimal OrderElementPrice();
    }
}
