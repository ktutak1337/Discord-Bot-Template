using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Reflection;

var builder = Host.CreateDefaultBuilder(args);

var configurationFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "appsettings.json");

builder.ConfigureAppConfiguration((builder) => builder
    .AddJsonFile(configurationFilePath)
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>());

builder.ConfigureLogging((hostingContext, logging) =>
{
    logging.SetMinimumLevel(LogLevel.None);
});

builder.ConfigureServices((context, services) =>
{
    var configurationRoot = context.Configuration;

    services.AddConfig(configurationRoot);
});

var host = builder.Build();

var bot = host.Services.GetRequiredService<IBotConfigurator>();
await bot.LaunchAsync();

await host.RunAsync();
