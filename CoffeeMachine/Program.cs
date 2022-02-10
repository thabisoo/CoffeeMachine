using CoffeeMachine.ApplicationLogic.Enums;
using CoffeeMachine.ApplicationLogic.Services.Interfaces;
using CoffeeMachine.DotNetCoreDI;
using CoffeeMachine.Helpers;
using System;
using System.Linq;

namespace CoffeeMachine
{
    class Program
    {
        private static readonly IServiceProvider _container = new ContainerBuilder().Build();
        private static readonly ICoffeeMachineService _coffeeMachineService = (ICoffeeMachineService) _container.GetService(typeof(ICoffeeMachineService));

        static void Main(string[] args)
        {
            var coffeeTypes = Enum.GetNames(typeof(CoffeeType));

            var coffeeTypeDictionary = coffeeTypes
                .Select((value, key) => new { value, key })
                .ToDictionary(x => (int)Enum.Parse(typeof(CoffeeType), x.value), x => x.value);

            ConsoleMessageHelper.IntoMessage();

            do
            {
                ConsoleMessageHelper.AvialableCoffeesDisplay(coffeeTypeDictionary);
                var response = int.Parse(Console.ReadLine());
                if (!coffeeTypeDictionary.Keys.Contains(response))
                {
                    ConsoleMessageHelper.InvalidCoffeeSelectionMessage();
                }
                else
                {
                    var result = _coffeeMachineService.Create((CoffeeType)response);
                    if(result.Beans <= 5)
                    {
                        ConsoleMessageHelper.LowBeanCapacityMessage();
                    }
                    ConsoleMessageHelper.CoffeeProcessedDisplay();
                }

            }
            while (Console.ReadLine().Contains("y"));
            Console.ReadLine();
        }
    }
}
