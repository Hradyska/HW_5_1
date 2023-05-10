using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HTTPClientFactoryPractice.Config;

namespace HTTPClientFactoryPractice
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
               .AddJsonFile("config.json")
               .Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices configureServices = new ConfigureServices();
            configureServices.ConfigServices(serviceCollection, configuration);
            var provider = serviceCollection.BuildServiceProvider();

            var app = provider.GetService<App>();
            await app!.Start();
        }
    }
}