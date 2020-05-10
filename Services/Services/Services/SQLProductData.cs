using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using AutoMapper;
using Interfaces.Services;
using Ninject;
using Ninject.Infrastructure.Language;
using Services.AutoMapper;
using Services.DI;
using Services.UoW;
using SmartCom.Domain.DTO.ShopElements;
using SmartCom.Domain.Models.BaseModels;
using SmartCom.Domain.ViewModels;

namespace Services.Services
{
    public class SQLProductData : IProductService
    {
        private readonly UnitOfWork _db;
        private readonly IMapper _mapper;

        public SQLProductData(UnitOfWork db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public IEnumerable<ProductDTO> GetProducts()
        {
            var productRepository = _db.Repository<ProductModel>().Get().AsQueryable().AsNoTracking();
             var productsDTO = _mapper.Map<IEnumerable<ProductDTO>>(productRepository);
            return productsDTO;
        }

        public ProductDTO GetProduct(Guid id) =>
            GetProducts().AsQueryable().AsNoTracking().FirstOrDefault(c => c.Id == id);
        //public ProductDTO GetProduct(Guid id)
        //{ 
        //    var productModel = _db.Repository<ProductModel>().FindById(id);
        //    var productDTO = _mapper.Map<ProductDTO>(productModel);
        //    return productDTO;
        //}

        public void AddProduct(ProductDTO product)
        {
            if (product is null)
                throw new ArgumentNullException(nameof(product));
            var productModel = _mapper.Map<ProductModel>(product);
            productModel.Id = Guid.NewGuid();
            _db.Repository<ProductModel>().Create(productModel);
            _db.Save();
        }

        public void Edit(Guid id, ProductDTO product)
        {
            if (product is null)
                throw new ArgumentNullException(nameof(product));
            var iowProduct = GetProduct(id);
            iowProduct.ProductName = product.ProductName;
            iowProduct.ProductCategory = product.ProductCategory;
            iowProduct.ProductCode = product.ProductCode;
            iowProduct.ProductPrice = product.ProductPrice;
            _db.Repository<ProductModel>().Update(_mapper.Map<ProductModel>(iowProduct));
            _db.Save();
        }

        public void Delete(ProductDTO product)
        {
            _db.Repository<ProductModel>().Remove(_mapper.Map<ProductModel>(product)); 
            _db.Save();
        }

    }
    
}
