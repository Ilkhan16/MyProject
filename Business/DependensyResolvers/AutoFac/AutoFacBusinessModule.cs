using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.CCS.Abstract;
using Business.CCS.Concrete;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccsess.Abstract;
using DataAccsess.Concrete.EntityFramework;

namespace Business.DependensyResolvers.AutoFac;

public class AutoFacBusinessModule:Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
        builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

        builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
        builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

        var assembly = System.Reflection.Assembly.GetExecutingAssembly();

        builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
    }
}