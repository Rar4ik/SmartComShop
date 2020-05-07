using System;
using System.Collections.Generic;
using Services.Repository;
using SmartCom.DAL.Context;
using SmartCom.Domain.Models.BaseModels;

namespace Services.UoW
{
    public class UnitOfWork : IDisposable
    {
        private readonly ApplicationDbContext _db;
        private Dictionary<string, object> _repositories;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(_db));
        }

        public UnitOfWork()
        {
            _db = new ApplicationDbContext();
        }

        public SQLGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, object>();
            }

            var type = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(SQLGenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _db);
                _repositories.Add(type, repositoryInstance);
            }

            return (SQLGenericRepository<TEntity>) _repositories[type];
        }

        //#region NotGeneric
        //private SQLGenericRepository<ProductModel> _genericProductRepository;
        //private SQLGenericRepository<CustomerModel> _genericCustomerRepository;
        //private SQLGenericRepository<OrderElementModel> _genericOrderElementRepository;
        //private SQLGenericRepository<OrderModel> _genericOrderRepository;
        //public SQLGenericRepository<ProductModel> Products
        //{
        //    get
        //    {
        //        if (_genericProductRepository != null)
        //            _genericProductRepository = new SQLGenericRepository<ProductModel>(_db);
        //        return _genericProductRepository;
        //    }
        //}
        //public SQLGenericRepository<CustomerModel> Customers
        //{
        //    get
        //    {
        //        if (_genericCustomerRepository != null)
        //            _genericCustomerRepository = new SQLGenericRepository<CustomerModel>(_db);
        //        return _genericCustomerRepository;
        //    }
        //}
        //public SQLGenericRepository<OrderElementModel> OrderElements
        //{
        //    get
        //    {
        //        if (_genericOrderElementRepository != null)
        //            _genericOrderElementRepository = new SQLGenericRepository<OrderElementModel>(_db);
        //        return _genericOrderElementRepository;
        //    }
        //}
        //public SQLGenericRepository<OrderModel> Orders
        //{
        //    get
        //    {
        //        if (_genericOrderRepository != null)
        //            _genericOrderRepository = new SQLGenericRepository<OrderModel>(_db);
        //        return _genericOrderRepository;
        //    }
        //} 
        //#endregion

        #region Saving
        public void Save()
        {
            _db.SaveChanges();
        }
        #endregion

        #region Disposing
        private bool _disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
