using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using HttpGet = System.Web.Http;
using System.Web.Mvc;
using AutoMapper;
using Interfaces.Services;
using SmartCom.Domain.ViewModels;

namespace SmartComShop.Controllers.ShopControllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _product;
        private readonly IMapper _mapper;

        public ProductController(IProductService product, IMapper mapper)
        {
            _product = product;
            _mapper = mapper;
        }

        // GET api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            IEnumerable<ProductViewModel> productView = _mapper.Map<IEnumerable<ProductViewModel>>(_product.GetProducts());
            return View(productView);
        }

        // GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        public void Post([HttpGet.FromBodyAttribute]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [HttpGet.FromBodyAttribute]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}