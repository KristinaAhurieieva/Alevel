using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using HomeWorkDevices;
using HomeWorkDevices.Config;
using HomeWorkDevices.Services.Abstractions;
using HomeWorkDevices.Services;
using HomeWorkDevices.Repositories;
using HomeWorkDevices.Models;

void ConfigureService(IServiceCollection serviceCollection, IConfiguration configuration)
{
    serviceCollection.AddOptions<LoggerOption>().Bind(configuration.GetSection("logger"));

    serviceCollection
        .AddTransient<SortingService>()
        .AddTransient<DeviceRepository>()
        .AddTransient<FlatModels>()
        .AddTransient<Socket>()
        .AddTransient<IDeviceService, DeviceService>()
        .AddTransient<IFlatService, FlatService>()
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
