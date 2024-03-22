using Microsoft.AspNetCore.Authorization;
using Microsoft.VisualBasic.FileIO;
using HttpWork.Config;
using HttpWork.Dtos.Requests;
using HttpWork.Dtos.Responses;
using HttpWork.Services.Abstractions;
using HttpWork.Services;
using HttpWork.Dtos;
using HttpWork;

void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
{
    serviceCollection.AddOptions<ApiOption>().Bind(configuration.GetSection("Api"));
    serviceCollection
        .AddLogging(configure => configure.AddConsole())
        .AddHttpClient()
        .AddTransient<IInternalHttpClientService, InternalHttpClientService>()
        .AddTransient<IUserService, UserService>()
        .AddTransient<IResourceService, ResourceService>()
        .AddTransient<IAuthorisationService, AuthorisationService>()
        .AddTransient<App>();
}

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("config.json")
    .Build();

var serviceCollection = new ServiceCollection();
ConfigureServices(serviceCollection, configuration);
var provider = serviceCollection.BuildServiceProvider();

var app = provider.GetService<App>();
await app!.Start();