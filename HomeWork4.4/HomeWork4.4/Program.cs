using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using FourModule;
using FourModule.Data;
using FourModule.Services;
using FourModule.Services.Abstractions;
using FourModule.Repositories;
using FourModule.Repositories.Abstractions;

void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
{
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    serviceCollection.AddDbContextFactory<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));
    serviceCollection.AddScoped<IDbContextWrapper<ApplicationDbContext>, DbContextWrapper<ApplicationDbContext>>();

    serviceCollection
        .AddLogging(configure => configure.AddConsole())
        .AddTransient<IPetService, PetService>()
        .AddTransient<ILocationService, LocationService>()
        .AddTransient<ICategoryService, CategoryService>()
        .AddTransient<IBreedService, BreedService>()
         .AddTransient<IPetRepository, PetRepository>()
        .AddTransient<ILocationRepository, LocationRepository>()
        .AddTransient<ICategoryRepository, CategoryRepository>()
        .AddTransient<IBreedRepository, BreedRepository>()
        .AddTransient<App>();
}

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("config.json")
    .Build();

var serviceCollection = new ServiceCollection();
ConfigureServices(serviceCollection, configuration);
var provider = serviceCollection.BuildServiceProvider();

var migrationSection = configuration.GetSection("Migration");
var isNeedMigration = migrationSection.GetSection("IsNeedMigration");

if (bool.Parse(isNeedMigration.Value))
{
    var dbContext = provider.GetService<ApplicationDbContext>();
    await dbContext!.Database.MigrateAsync();
}

var app = provider.GetService<App>();
await app!.Start();