using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using Interfaces.Services;
using Services.UoW;
using SmartCom.Domain.DTO.ShopElements;
using SmartCom.Domain.Models.BaseModels;
using SmartCom.Domain.Models.BaseModels.Identity;

namespace Services.Services
{
    public class SQLCustomerData : ICustomerService
    {
        private readonly UnitOfWork _db;
        private readonly IMapper _mapper;

        public SQLCustomerData(UnitOfWork db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            using (var context = new UnitOfWork())
            {
                var customerRepository = context.Repository<CustomerDTO>().Get().AsQueryable();
                var customerDTO = _mapper.Map<IEnumerable<CustomerDTO>>(customerRepository);
                return customerDTO.AsEnumerable();
            }
        }

        public CustomerDTO GetCustomer(Guid id) => GetCustomers().FirstOrDefault(c => c.Id == id);

        public void AddCustomer(CustomerDTO customer)
        {
            if(customer is null)
                throw new ArgumentNullException();
            var customerModel = _mapper.Map<CustomerModel>(customer);
            customerModel.Id = Guid.NewGuid();
            _db.Repository<CustomerModel>().Create(customerModel);
            _db.Save();
        }

        public void Edit(Guid id, CustomerDTO customer)
        {
            using (var context = new UnitOfWork())
            {
                if(customer is null)
                    throw new ArgumentNullException();
                var iowCustomer = GetCustomer(id);
                iowCustomer.Code = customer.Code;
                iowCustomer.CustomerAddress = customer.CustomerAddress;
                iowCustomer.CustomerName = customer.CustomerName;
                iowCustomer.CustomerDiscount = customer.CustomerDiscount;
                context.Repository<CustomerModel>().Update(_mapper.Map<CustomerModel>(iowCustomer));
                context.Save();
            }
        }

        public void Delete(CustomerDTO customer)
        {
            using (var context = new UnitOfWork())
            {
                context.Repository<CustomerModel>().Remove(_mapper.Map<CustomerModel>(customer));
                context.Save();
            }
        }
    }
}
