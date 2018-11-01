using System;
using Autofac;
using Autofac.Integration.Wcf;
using Common;

namespace Publisher.Soap
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ConfigurateIoc();
        }

        private static void ConfigurateIoc()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(typeof(StorageModule).Assembly);
            builder.RegisterType<RateService>()
                .As<IRateService>()
                .OnActivated(e => e.Instance.Storage = e.Context.Resolve<IStorage>());

            AutofacHostFactory.Container = builder.Build();
        }
    }
}