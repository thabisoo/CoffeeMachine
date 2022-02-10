using CoffeeMachine.ApplicationLogic.Entities.Interfaces;
using CoffeeMachine.ApplicationLogic.Services.Interfaces;
using CoffeeMachine.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine.ApplicationLogic.Services
{
    public class CappuccinoDrinkService : ICoffeeDrinkService
    {
        private readonly IAppSettingsHelper _appSettingsHelper;
        public CappuccinoDrinkService(IAppSettingsHelper appSettingsHelper)
        {
            _appSettingsHelper = appSettingsHelper;
        }

        public ICoffeeUnitEntity Create(ICoffeeUnitEntity coffeeUnits)
        {
            if(coffeeUnits == null)
            {
                throw new ArgumentNullException("Missing coffee units");
            }

            if(coffeeUnits.Beans - _appSettingsHelper.GetCappuccinoRequiredBeans() < 0)
            {
                throw new ApplicationException("Not enough beans.");
            }

            if (coffeeUnits.Milk - _appSettingsHelper.GetCappuccinoRequiredMilk() < 0)
            {
                throw new ApplicationException("Not enough milk.");
            }

            var a = _appSettingsHelper.GetCappuccinoRequiredBeans();
            coffeeUnits.Beans -= _appSettingsHelper.GetCappuccinoRequiredBeans();
            coffeeUnits.Milk -= _appSettingsHelper.GetCappuccinoRequiredMilk();
            return coffeeUnits;
        }
    }
}
