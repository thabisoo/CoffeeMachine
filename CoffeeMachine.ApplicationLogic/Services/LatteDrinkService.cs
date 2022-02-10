using CoffeeMachine.ApplicationLogic.Entities.Interfaces;
using CoffeeMachine.ApplicationLogic.Services.Interfaces;
using CoffeeMachine.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine.ApplicationLogic.Services
{
    public class LatteDrinkService : ICoffeeDrinkService
    {
        private readonly IAppSettingsHelper _appSettingsHelper;
        public LatteDrinkService(IAppSettingsHelper appSettingsHelper)
        {
            _appSettingsHelper = appSettingsHelper;
        }

        public ICoffeeUnitEntity Create(ICoffeeUnitEntity coffeeUnits)
        {
            if (coffeeUnits == null)
            {
                throw new ArgumentNullException("Missing coffee units");
            }

            if (coffeeUnits.Beans - _appSettingsHelper.GetLatteRequiredBeans() < 0)
            {
                throw new ApplicationException("Not enough beans.");
            }

            if (coffeeUnits.Milk - _appSettingsHelper.GetLatteRequiredMilk() < 0)
            {
                throw new ApplicationException("Not enough milk.");
            }

            coffeeUnits.Beans -= _appSettingsHelper.GetLatteRequiredBeans();
            coffeeUnits.Milk -= _appSettingsHelper.GetLatteRequiredMilk();
            return coffeeUnits;
        }
    }
}
