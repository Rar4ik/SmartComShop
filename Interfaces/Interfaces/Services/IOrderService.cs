using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCom.Domain.DTO.ShopElements;

namespace Interfaces.Services
{
    public interface IOrderService
    {
        CustomerDTO GetCustomer();
        DateTime RequestedDate();
        DateTime DeliveredDate();
        int? OrderNumber();
        string OrderStatus();
    }
}
