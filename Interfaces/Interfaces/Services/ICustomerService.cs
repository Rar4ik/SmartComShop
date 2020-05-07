using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCom.Domain.DTO.ShopElements;

namespace Interfaces.Services
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDTO> GetCustomers();
        string GetCustomerCode();
        string GetCustomer();
        string GetCustomerAddress();
        int? GetCustomerDiscount();
    }
}
