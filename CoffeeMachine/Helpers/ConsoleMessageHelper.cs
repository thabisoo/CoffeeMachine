using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CoffeeMachine.Helpers
{
    public class ConsoleMessageHelper
    {
        public static void IntoMessage()
        {
            Console.WriteLine("What coffee would you like?");
        }

        public static void InvalidCoffeeSelectionMessage()
        {
            Console.WriteLine($"Invalid selection.");
            Console.WriteLine($"Enter 'y' to correct your selection, or 'off' to turn off the machine.");
        }

        public static void CoffeeProcessedDisplay()
        {
            Console.WriteLine($"Would you like another one?");
            Console.WriteLine($"Enter 'y' if yes, or 'off' to turn off the machine.");
            Console.WriteLine("");
        }

        public static void LowBeanCapacityMessage()
        {
            Console.WriteLine("The machine is currently running low on beans");
        }

        public static void AvialableCoffeesDisplay(IDictionary<int, string> avialableCoffees)
        {
            Console.WriteLine("");
            foreach (var coffee in avialableCoffees)
            {
                Console.WriteLine($"Enter {coffee.Key} for {Regex.Replace(coffee.Value, "([a-z])([A-Z])", "$1 $2")}");
            }
        }
    }
}
