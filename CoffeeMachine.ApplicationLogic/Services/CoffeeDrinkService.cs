using CoffeeMachine.ApplicationLogic.Entities.Interfaces;
using CoffeeMachine.ApplicationLogic.Services.Interfaces;
using CoffeeMachine.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine.ApplicationLogic
{
    public class CoffeeDrinkService : ICoffeeDrinkService
    {
        private readonly IAppSettingsHelper _appSettingsHelper;
        public CoffeeDrinkService(IAppSettingsHelper appSettingsHelper)
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

            if (coffeeUnits.Milk - _appSettingsHelper.GetCoffeeRequiredMilk() < 0)
            {
                throw new ApplicationException("Not enough milk.");
            }

            coffeeUnits.Beans -= _appSettingsHelper.GetCoffeeRequiredBeans();
            coffeeUnits.Milk -= _appSettingsHelper.GetCoffeeRequiredMilk();
            return coffeeUnits;
        }
    }
}
