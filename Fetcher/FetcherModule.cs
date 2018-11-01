using Autofac;
using Fetcher.Core;
using NLog;

namespace Fetcher
{
    public class FetcherModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Core.Fetcher>().As<IFetcher>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ResponseParser>().As<IResponseParser>();
            builder.Register(c => LogManager.GetLogger("*")).As<ILogger>();
        }
    }
}