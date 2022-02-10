using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine.Common.Helpers
{
    public class AppSettingsHelper : IAppSettingsHelper
    {
        const string TOTAL_BEANS = "Settings:coffeeMachineTotalBeanUnits";
        const string TOTAL_MILK = "Settings:coffeeMachineTotalMilkUnits";
        const string CAPPUCCINO_REQUIRED_BEANS = "Settings:Cappuccino:requiredBeans";
        const string CAPPUCCINO_REQUIRED_MILK = "Settings:Cappuccino:requiredMilk";
        const string LATTE_REQUIRED_BEANS = "Settings:Latte:requiredBeans";
        const string LATTE_REQUIRED_MILK = "Settings:Latte:requiredMilk";
        const string COFFEE_REQUIRED_BEANS = "Settings:coffee:requiredBeans";
        const string COFFEE_REQUIRED_MILK = "Settings:coffee:requiredMilk";

        private readonly IConfiguration _configuration;

        public AppSettingsHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetAppSetting(string key)
        {
            return _configuration.GetSection(key).Value;
        }

        public int GetTotalMachineBeans()
        {
            return int.Parse(GetAppSetting(TOTAL_BEANS));
        }

        public int GetTotalMachineMilk()
        {
            return int.Parse(GetAppSetting(TOTAL_MILK));
        }

        public int GetCappuccinoRequiredBeans()
        {
            return int.Parse(GetAppSetting(CAPPUCCINO_REQUIRED_BEANS));
        }

        public int GetCappuccinoRequiredMilk()
        {
            return int.Parse(GetAppSetting(CAPPUCCINO_REQUIRED_MILK));
        }

        public int GetLatteRequiredBeans()
        {
            return int.Parse(GetAppSetting(LATTE_REQUIRED_BEANS));
        }

        public int GetLatteRequiredMilk()
        {
            return int.Parse(GetAppSetting(LATTE_REQUIRED_MILK));
        }

        public int GetCoffeeRequiredBeans()
        {
            return int.Parse(GetAppSetting(COFFEE_REQUIRED_BEANS));
        }

        public int GetCoffeeRequiredMilk()
        {
            return int.Parse(GetAppSetting(COFFEE_REQUIRED_MILK));
        }
    }
}
