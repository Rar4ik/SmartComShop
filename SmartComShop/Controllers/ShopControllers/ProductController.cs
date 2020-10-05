using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using HttpGet = System.Web.Http;
using System.Web.Mvc;
using AutoMapper;
using Interfaces.Services;
using Microsoft.Owin.Security.Provider;
using SmartCom.Domain.DTO.ShopElements;
using SmartCom.Domain.Models.BaseModels.Identity;
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

        [HttpGet]
        //public ActionResult Get()
        //{
        //    IEnumerable<ProductViewModel> productView = 
        //        _mapper.Map<IEnumerable<ProductViewModel>>(_product.GetProducts());
        //    return View(productView);
        //}
        public JsonResult Get()
        {
          IEnumerable<ProductViewModel> productView =
            _mapper.Map<IEnumerable<ProductViewModel>>(_product.GetProducts());
          return Json(productView, JsonRequestBehavior.AllowGet);
        }
    #region GetByCode GET&POST
    [HttpGet, Authorize(Roles = UserAdmin.Name)]
        public ActionResult GetByCode(Guid id)
        {

            ProductViewModel productView = _mapper.Map<ProductViewModel>(_product.GetProduct(id));
            if (productView is null)
                return HttpNotFound();
            return View(productView);
        }

        [HttpPost, Authorize(Roles = UserAdmin.Name)]
        public ActionResult GetByCode(ProductViewModel product)
        {
            if (product is null)
                throw new ArgumentOutOfRangeException(nameof(product));

            if (!ModelState.IsValid)
                return View(product);

            var id = product.Id;
            _product.Edit(id, _mapper.Map<ProductDTO>(product));
            return RedirectToAction("Get");
        }
        #endregion

        #region Create GET&POST
        [HttpGet, Authorize(Roles = UserAdmin.Name)]
        public ActionResult Create() => View(new ProductViewModel());

        [HttpPost, Authorize(Roles = UserAdmin.Name)]
        public ActionResult Create(ProductViewModel product)
        {
            if (!ModelState.IsValid)
                return View(product);

            _product.AddProduct(_mapper.Map<ProductDTO>(product));
            return RedirectToAction("Get");
        } 
        #endregion

        // DELETE api/<controller>/5
        [Authorize(Roles = UserAdmin.Name)]
        public ActionResult Delete(ProductViewModel product)
        {
            _product.Delete(_mapper.Map<ProductDTO>(product));
            return RedirectToAction("Get");
        }
    }
}
