using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Interfaces.Services;
using SmartCom.Domain.DTO.ShopElements;
using SmartCom.Domain.ViewModels;

namespace SmartComShop.Controllers.ShopControllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customer;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customer, IMapper mapper)
        {
            _customer = customer;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Get()
        {
            IEnumerable<UserCustomerViewModel> customerView =
                _mapper.Map<IEnumerable<UserCustomerViewModel>>(_customer.GetCustomers());
            return View(customerView);
        }


        #region Post&Get ById

        [HttpGet]
        public ActionResult GetById(Guid id)
        {
            UserCustomerViewModel customerView =
                _mapper.Map<UserCustomerViewModel>(_customer.GetCustomer(id));
            return View(customerView);
        }

        [HttpPost]
        public ActionResult GetById(UserCustomerViewModel customerView)
        {
            if (customerView is null)
                throw new ArgumentNullException();
            if (!ModelState.IsValid)
                return View(customerView);
            var id = customerView.Id;
            _customer.Edit(id, _mapper.Map<CustomerDTO>(customerView));
            return RedirectToAction("Get");
        }

        #endregion

        #region Post&Get Create

        [HttpGet]
        public ActionResult Create() => View(new UserCustomerViewModel());

        [HttpPost]
        public ActionResult Create(UserCustomerViewModel customerView)
        {
            if (!ModelState.IsValid)
                return View(customerView);
            _customer.AddCustomer(_mapper.Map<CustomerDTO>(customerView));
            return RedirectToAction("Get");
        }

    #endregion

        public ActionResult Delete(UserCustomerViewModel customerView)
        {
            _customer.Delete(_mapper.Map<CustomerDTO>(customerView));
            return RedirectToAction("Get");
        }
    }
}