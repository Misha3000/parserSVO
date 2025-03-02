using Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Parser;

namespace Client;

static class Program
{
    public static IServiceProvider ServiceProvider { get; private set; }
    
    [STAThread]
    static void Main()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
        
        var services = new ServiceCollection();
        ConfigureService(services);
        services.AddDataServices(configuration);
        services.AddHttpClient();
        ServiceProvider = services.BuildServiceProvider();
        
        ApplicationConfiguration.Initialize();
        Application.Run(ServiceProvider.GetRequiredService<MainForm>());
    }

    private static void ConfigureService(ServiceCollection services)
    {
        services.AddScoped<IParserApi, ParserApi>();
        
        services.AddScoped<MainForm>();
    }
}