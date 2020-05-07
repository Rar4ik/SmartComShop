using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Services;
using SmartCom.Domain.DTO.ShopElements;

namespace Services.Services
{
    public class SQLOrderService : IOrderService
    {
        public CustomerDTO GetCustomer()
        {
            throw new NotImplementedException();
        }

        public DateTime RequestedDate()
        {
            throw new NotImplementedException();
        }

        public DateTime DeliveredDate()
        {
            throw new NotImplementedException();
        }

        public int? OrderNumber()
        {
            throw new NotImplementedException();
        }

        public string OrderStatus()
        {
            throw new NotImplementedException();
        }
    }
}
