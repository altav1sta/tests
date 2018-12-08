using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Business.Services.Abstract;
using DiModules;
using MvcApp.Infrastructure;

namespace MvcApp
{
    internal sealed class AutofacConfig
    {
        public static void RegisterDependencies(ContainerBuilder builder)
        {
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModule<AutofacModule>();
            builder.RegisterType<BusinessConfiguration>().As<IBusinessConfiguration>().SingleInstance();
            builder.RegisterType<ServiceFactory>().AsSelf().SingleInstance();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}