using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Interfaces.Services;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using Services.AutoMapper;
using Services.Services;
using Services.UoW;

namespace Services.DI
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<SQLProductData>()
                .WithConstructorArgument("db", new UnitOfWork());
            #region Mapper
            var mapperConfiguration = CreateConfiguration();
            Bind<MapperConfiguration>().ToConstant(mapperConfiguration).InSingletonScope();
            Bind<IMapper>().ToMethod(ctx =>
                new Mapper(mapperConfiguration, type => ctx.Kernel.Get(type)));
            #endregion
        }
        private MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperDTO());
                cfg.AddProfile(new AutoMapperViewModel());
            });

            return config;
        }

        public static void Registration()
        {
            NinjectModule registration = new NinjectRegistrations();
            var kernel = new StandardKernel(registration);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
    public class Root
    {
        public Root(IMapper mapper)
        {

        }
    }
}
