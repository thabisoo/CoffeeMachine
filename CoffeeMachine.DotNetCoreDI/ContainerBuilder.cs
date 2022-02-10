using System;
using System.IO;
using CoffeeMachine.ApplicationLogic;
using CoffeeMachine.ApplicationLogic.Entities.Interfaces;
using CoffeeMachine.ApplicationLogic.Enums;
using CoffeeMachine.ApplicationLogic.Services;
using CoffeeMachine.ApplicationLogic.Services.Interfaces;
using CoffeeMachine.Common.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeMachine.DotNetCoreDI
{
    public class ContainerBuilder
    {
        public IServiceProvider Build()
        {
            var path = Directory.GetCurrentDirectory();
            var builder = new ConfigurationBuilder()
            .SetBasePath(path) //<--You would need to set the path
            .AddJsonFile("appsettings.json"); //or what ever file you have the settings

            IConfiguration configuration = builder.Build();

            var container = new ServiceCollection();

            container.AddScoped<ICoffeeMachineService, CoffeeMachineService>();
            container.AddScoped<ICoffeeUnitEntity, CoffeeUnitEntity>();
            container.AddScoped<CoffeeDrinkService>();
            container.AddScoped<CoffeeWithoutMilkDrinkService>();
            container.AddScoped<LatteDrinkService>();
            container.AddScoped<CappuccinoDrinkService>();
            container.AddScoped<IConfiguration>(_ => configuration);
            container.AddSingleton<IAppSettingsHelper, AppSettingsHelper>();

            container.AddTransient<Func<CoffeeType, ICoffeeDrinkService>>(serviceProvider => serviceTypeName =>
            {
                switch (serviceTypeName)
                {
                    case CoffeeType.CoffeeWithMilk:
                        return serviceProvider.GetService<CoffeeDrinkService>();
                    case CoffeeType.CoffeeWithoutMilk:
                        return serviceProvider.GetService<CoffeeWithoutMilkDrinkService>();
                    case CoffeeType.Cappuccino:
                        return serviceProvider.GetService<CappuccinoDrinkService>();
                    case CoffeeType.Latte:
                        return serviceProvider.GetService<LatteDrinkService>();
                    default:
                        return null;
                }
            });

            return container.BuildServiceProvider();
        }
    }
}
