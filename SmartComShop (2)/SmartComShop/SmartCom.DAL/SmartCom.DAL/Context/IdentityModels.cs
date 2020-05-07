using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using SmartCom.Domain.Models.BaseModels;
using SmartCom.Domain.Models.BaseModels.Identity;

namespace SmartCom.DAL.Context
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<OrderElementModel> OrderElements { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<ProductModel> Products { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<OrderModel>()
        //        .HasRequired(c => c.Customer);

        //    modelBuilder.Entity<OrderElementModel>()
        //        .HasRequired(c => c.Order);

        //    modelBuilder.Entity<OrderElementModel>()
        //        .
        //}

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}