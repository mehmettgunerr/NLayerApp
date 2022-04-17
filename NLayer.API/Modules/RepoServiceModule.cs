using Autofac;
using Module = Autofac.Module;
using NLayer.Repository;
using NLayer.Service.Mapping;
using System.Reflection;
using NLayer.Repository.Repositories;
using NLayer.Core.Repositories;
using NLayer.Service.Service;
using NLayer.Core.Services;
using NLayer.Repository.UnitOfWorks;
using NLayer.Core.UnitOfWorks;
using NLayer.Caching;

namespace NLayer.API.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext)); //repository katmanı herhangi bir class
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile)); //serivce katmanı herhangi bir class

            builder.RegisterAssemblyTypes(apiAssembly,repoAssembly,serviceAssembly).Where(x=>x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope().InstancePerLifetimeScope();

            builder.RegisterType<ProductServiceWithCaching>().As<IProductService>();
            //InstancePerlifeTimeScope -> scope
            //instanceperdependency -> trasient
        }
    }
}
