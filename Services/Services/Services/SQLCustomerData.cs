using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Services;
using SmartCom.Domain.DTO.ShopElements;

namespace Services.Services
{
    class SQLCustomerData : ICustomerService
    {
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public string GetCustomerCode()
        {
            throw new NotImplementedException();
        }

        public string GetCustomer()
        {
            throw new NotImplementedException();
        }

        public string GetCustomerAddress()
        {
            throw new NotImplementedException();
        }

        public int? GetCustomerDiscount()
        {
            throw new NotImplementedException();
        }
    }
}
