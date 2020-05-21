using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SmartCom.DAL.Context;
using SmartCom.Domain.Models.BaseModels;
using SmartCom.Domain.Models.BaseModels.Identity;

namespace SmartCom.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SmartCom.DAL.Context.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SmartCom.DAL.Context.ApplicationDbContext context)
        {
            #region InitialCommitCommented

            //#region Customers
            //CustomerModel customer1 = new CustomerModel
            //{
            //    CustomerAddress = "Улица Тестовая, д.1",
            //    CustomerCode = "0001-2020",
            //    CustomerDiscount = 5,
            //    CustomerName = "Жора",
            //    Id = Guid.NewGuid()
            //};
            //CustomerModel customer2 = new CustomerModel
            //{
            //    CustomerAddress = "Улица Комочковая, д.2",
            //    CustomerCode = "0002-2020",
            //    CustomerDiscount = 10,
            //    CustomerName = "Антонио",
            //    Id = Guid.NewGuid()
            //};
            //CustomerModel customer3 = new CustomerModel
            //{
            //    CustomerAddress = "Улица Сгущенная, д.3",
            //    CustomerCode = "0003-2020",
            //    CustomerDiscount = 15,
            //    CustomerName = "Миневра",
            //    Id = Guid.NewGuid()
            //};

            //context.Customers.Add(customer1);
            //context.Customers.Add(customer2);
            //context.Customers.Add(customer3);
            //#endregion

            //#region Orders
            //OrderModel order1 = new OrderModel
            //{
            //    Customer = customer1,
            //    CustomerId = customer1.Id,
            //    OrderStatus = "Done",
            //    OrderNumber = 1,
            //    OrderDateRequested = DateTime.Today,
            //    OrderDateDelivered = DateTime.Now,
            //    Id = Guid.NewGuid()
            //};
            //OrderModel order2 = new OrderModel
            //{
            //    Customer = customer2,
            //    CustomerId = customer2.Id,
            //    OrderStatus = "Done",
            //    OrderNumber = 2,
            //    OrderDateRequested = DateTime.Today,
            //    OrderDateDelivered = DateTime.Now,
            //    Id = Guid.NewGuid()
            //};

            //context.Orders.Add(order1);
            //context.Orders.Add(order2);
            //#endregion

            //#region Products
            //ProductModel product1 = new ProductModel
            //{
            //    ProductCategory = "Выпечка",
            //    ProductCode = "01",
            //    ProductName = "Блин",
            //    ProductPrice = 100,
            //    Id = Guid.NewGuid(),
            //};
            //ProductModel product2 = new ProductModel
            //{
            //    ProductCategory = "Выпечка",
            //    ProductCode = "02",
            //    ProductName = "Оладушек",
            //    ProductPrice = 90,
            //    Id = Guid.NewGuid()
            //};
            //ProductModel product3 = new ProductModel
            //{
            //    ProductCategory = "Мороженное",
            //    ProductCode = "03",
            //    ProductName = "Пломбир",
            //    ProductPrice = 100,
            //    Id = Guid.NewGuid()
            //};

            //context.Products.Add(product1);
            //context.Products.Add(product2);
            //context.Products.Add(product3);
            //#endregion

            //#region OrdersElements
            //OrderElementModel orderElement1 = new OrderElementModel
            //{
            //    Order = order1,
            //    OrderElementAmount = 1,
            //    OrderElementPrice = (decimal)product1.ProductPrice,
            //    Product = new List<ProductModel> { product1 },
            //    Id = Guid.NewGuid(),
            //    OrderId = order1.Id,
            //    ProductId = product1.Id
            //};
            //OrderElementModel orderElement2 = new OrderElementModel
            //{
            //    Order = order2,
            //    OrderElementAmount = 2,
            //    OrderElementPrice = (decimal)product2.ProductPrice,
            //    Product = new List<ProductModel> { product2, product3 },
            //    Id = Guid.NewGuid(),
            //    OrderId = order2.Id,
            //    ProductId = product2.Id
            //};

            //context.OrderElements.Add(orderElement1);
            //context.OrderElements.Add(orderElement2);
            //#endregion 

            #endregion

            #region AdminCreation

            if (!context.Roles.Any(c => c.Name == UserAdmin.Name))
            {
                context.Roles.Add(new IdentityRole(UserAdmin.Name));
                context.SaveChanges();
            }

            if (!context.Users.Any(u => u.UserName == UserAdmin.Name))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var user = new User() { UserName = UserAdmin.Name };
                manager.Create(user, UserAdmin.Password);

                manager.AddToRole(user.Id, UserAdmin.Name);
            }
            #endregion

            base.Seed(context);
        }
    }
}
