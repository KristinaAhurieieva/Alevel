using System.Collections;
using System.Collections.Generic;
using HomeWork3._1;
using HomeWork3._1.Collection.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HomeWork3._1.Collection;

void ConfigureService(IServiceCollection serviceCollection)
{
    serviceCollection
        .AddScoped<IPersonalisedCollection<string>, PersonalisedCollection<string>>()
        .AddTransient<Startup>();
}

var serviceCollection = new ServiceCollection();
    ConfigureService(serviceCollection);

    var provider = serviceCollection.BuildServiceProvider();

    var startup = provider.GetService<Startup>();
    startup.Start();

