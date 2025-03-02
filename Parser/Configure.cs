using Microsoft.Extensions.DependencyInjection;
using Data;
using Microsoft.Extensions.Configuration;

namespace Parser;

public static class Configure
{
    public static IServiceCollection AddParser(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDataServices(configuration);
        services.AddSingleton<IParserApi, ParserApi>();
        services.AddHttpClient();
        
        return services;
    }
}