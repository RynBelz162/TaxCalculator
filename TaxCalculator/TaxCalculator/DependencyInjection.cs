using System;
using Microsoft.Extensions.DependencyInjection;
using TaxCalculator.Services;
using TaxCalculator.ViewModels;
using TaxCalculator.Http;
using Microsoft.Extensions.Configuration;
using TaxCalculator.Models.TaxJar;
using System.Reflection;

namespace TaxCalculator
{
    public static class DependencyInjection
    {
        public static IServiceProvider ServiceProvider;

        public static void Init()
        {
            var collection = new ServiceCollection();
            RegisterServices(collection);
            RegisterVms(collection);
            RegisterHttpClients(collection);
            RegisterConfiguration(collection);

            ServiceProvider = collection.BuildServiceProvider();
        }

        private static void RegisterServices(ServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<ITaxService, TaxService>();
        }

        private static void RegisterVms(ServiceCollection serviceCollection)
        {
            serviceCollection
                    .AddTransient<MainVm>();
        }

        private static void RegisterHttpClients(ServiceCollection serviceCollection)
        {
            serviceCollection
                .AddHttpClient<ITaxJarClient, TaxJarClient>();
                
        }

        private static void RegisterConfiguration(ServiceCollection serviceCollection)
        {
            var asm = Assembly
                .GetAssembly(typeof(DependencyInjection));


           var appSettingsStream = asm.GetManifestResourceStream("TaxCalculator.appsettings.json");

            var configuration = new ConfigurationBuilder()
                .AddJsonStream(appSettingsStream)
                .Build();

            var taxJarSettings = new TaxJarSettings();
            configuration.Bind("TaxJar", taxJarSettings);
            serviceCollection.AddSingleton(taxJarSettings);
        }
    }
}
