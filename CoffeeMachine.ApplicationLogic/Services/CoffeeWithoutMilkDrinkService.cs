using CoffeeMachine.ApplicationLogic.Entities.Interfaces;
using CoffeeMachine.ApplicationLogic.Services.Interfaces;
using CoffeeMachine.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine.ApplicationLogic.Services
{
    public class CoffeeWithoutMilkDrinkService : ICoffeeDrinkService
    {
        private readonly IAppSettingsHelper _appSettingsHelper;
        public CoffeeWithoutMilkDrinkService(IAppSettingsHelper appSettingsHelper)
        {
            _appSettingsHelper = appSettingsHelper;
        }

        public ICoffeeUnitEntity Create(ICoffeeUnitEntity coffeeUnits)
        {
            if (coffeeUnits == null)
            {
                throw new ArgumentNullException("Missing coffee units");
            }

            if (coffeeUnits.Beans - _appSettingsHelper.GetCoffeeRequiredBeans() < 0)
            {
                throw new ApplicationException("Not enough beans.");
            }

            coffeeUnits.Beans -= _appSettingsHelper.GetCoffeeRequiredBeans();
            return coffeeUnits;
        }
    }
}
