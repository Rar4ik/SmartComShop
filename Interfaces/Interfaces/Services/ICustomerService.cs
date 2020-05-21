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
        CustomerDTO GetCustomer(Guid id);
        void AddCustomer(CustomerDTO customer);
        void Edit(Guid id, CustomerDTO customer);
        void Delete(CustomerDTO customer);
    }
}
