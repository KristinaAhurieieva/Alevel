using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HomeWorkDevices;
using HomeWorkDevices.Config;
using HomeWorkDevices.Services.Abstractions;
using HomeWorkDevices.Services;
using HomeWorkDevices.Repositories;
using HomeWorkDevices.Models;
using HomeWorkDevices.Repositories.Abstractions;

void ConfigureService(IServiceCollection serviceCollection, IConfiguration configuration)
{
    serviceCollection.AddOptions<LoggerOption>().Bind(configuration.GetSection("logger"));

    serviceCollection
        .AddTransient<IDeviceRepository<Device>, DeviceRepository<Device>>()
        .AddTransient<SocketService>()
        .AddTransient<IDeviceService<Device>, DeviceService<Device>>()
        .AddTransient<StartConnection>()
        .AddSingleton<ILoggerService, LoggerService>();
}

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("config.json")
    .Build();

var serviceCollection = new ServiceCollection();
ConfigureService(serviceCollection, configuration);

var provider = serviceCollection.BuildServiceProvider();

var startConnection = provider.GetService<StartConnection>();
startConnection.Start();
