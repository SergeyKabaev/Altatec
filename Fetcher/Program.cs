using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Autofac;
using Autofac.Core;
using Common;
using Fetcher.Core;

namespace Fetcher
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = NLog.LogManager.GetCurrentClassLogger();
            try
            {
                logger.Info("app start ...");
                var containerBuilder = new ContainerBuilder();
                containerBuilder.RegisterAssemblyModules(typeof(FetcherModule).Assembly);
                containerBuilder.RegisterAssemblyModules(typeof(StorageModule).Assembly);
                IContainer container = containerBuilder.Build();
                container.Resolve<IFetcher>().Run();
                logger.Info("app started");
            }
            catch (Exception e)
            {
                logger.Fatal(e.GetLastInnerException(), "app fatal error");
                throw;
            }
        }
    }
}
