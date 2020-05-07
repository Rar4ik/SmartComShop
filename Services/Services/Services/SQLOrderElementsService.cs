using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Services;
using SmartCom.Domain.DTO.ShopElements;

namespace Services.Services
{
    public class SQLOrderElementsService : IOrderElementService
    {
        public IEnumerable<ProductDTO> GetProducts()
        {
            throw new NotImplementedException();
        }

        public OrderDTO Order()
        {
            throw new NotImplementedException();
        }

        public int OrderElementAmount()
        {
            throw new NotImplementedException();
        }

        public decimal OrderElementPrice()
        {
            throw new NotImplementedException();
        }
    }
}
