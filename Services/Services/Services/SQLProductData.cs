using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Interfaces.Services;
using Ninject;
using Ninject.Infrastructure.Language;
using Services.AutoMapper;
using Services.DI;
using Services.UoW;
using SmartCom.Domain.DTO.ShopElements;
using SmartCom.Domain.Models.BaseModels;

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
            var productRepository = _db.Repository<ProductModel>().Get().AsQueryable();
            var productDTO = _mapper.Map<IEnumerable<ProductDTO>>(productRepository);
            return productDTO.AsEnumerable();
        }

        public string GetProductCode()
        {
            throw new NotImplementedException();
        }

        public string GetProduct()
        {
            throw new NotImplementedException();
        }

        public string GetProductCategory()
        {
            throw new NotImplementedException();
        }

        public decimal GetProductPrice()
        {
            throw new NotImplementedException();
        }
    }
}
