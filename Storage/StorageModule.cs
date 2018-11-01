using Autofac;
using Common.Dal;

namespace Common
{
    public class StorageModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Storage>().As<IStorage>();
            builder.RegisterType<Config>().As<IConfig>();
            builder.RegisterType<RateRepository>().As<IRateRepository>();
        }
    }
}