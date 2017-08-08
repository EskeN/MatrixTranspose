using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using MatrixTranspose.Services;
using MatrixTranspose.Services.Interfaces;

namespace MatrixTranspose
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<CsvFileParser>().As<IFileParser>();
            builder.RegisterType<RandomWrapper>().As<IRandomWrapper>();
            builder.RegisterType<MatrixHelper>().As<IMatrixHeper>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}