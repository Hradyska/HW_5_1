using HTTPClientFactoryPractice.Services;
using HTTPClientFactoryPractice.Services.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
namespace HTTPClientFactoryPractice.Config
{
    public class ConfigureServices
    {
        public void ConfigServices(ServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddOptions<APIOption>().Bind(configuration.GetSection("Api"));
            serviceCollection
                .AddLogging(configure => configure.AddConsole())
                .AddHttpClient()
                .AddTransient<IInternalHTTPClientService, InternalHTTPClientService>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<IAuthService, ResourceService>()
                .AddTransient<IRegisterService, AuthService>()
                .AddTransient<App>();
        }
    }
}
