using Autofac;
using Business.Services.Abstract;
using Business.Services.Concrete;

namespace DiModules
{
    /// <summary>
    /// Autofac module that registers all dependencies
    /// </summary>
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryService>().As<ICategoryService>();

            base.Load(builder);
        }
    }
}
