using CoffeeMachine.ApplicationLogic.Entities.Interfaces;
using CoffeeMachine.ApplicationLogic.Enums;
using CoffeeMachine.ApplicationLogic.Services.Interfaces;
using CoffeeMachine.Common.Helpers;
using Microsoft.Extensions.Configuration;
using System;

namespace CoffeeMachine.ApplicationLogic
{
    public class CoffeeMachineService : ICoffeeMachineService
    {
        private readonly Func<CoffeeType, ICoffeeDrinkService> _coffeeDrinkServiceResolver;
        private readonly ICoffeeUnitEntity _coffeeUnits;
        private readonly IAppSettingsHelper _appSettingsHelper;

        public CoffeeMachineService(Func<CoffeeType, ICoffeeDrinkService> coffeeDrinkServiceResolver,
            IAppSettingsHelper appSettingsHelper,
            ICoffeeUnitEntity coffeeUnitEntity)
        {
            _coffeeDrinkServiceResolver = coffeeDrinkServiceResolver;
            _appSettingsHelper = appSettingsHelper;

            _coffeeUnits = coffeeUnitEntity;
            _coffeeUnits.Beans = _appSettingsHelper.GetTotalMachineBeans();
            _coffeeUnits.Milk = _appSettingsHelper.GetTotalMachineMilk();
        }

        public ICoffeeUnitEntity Create(CoffeeType coffeeType)
        {
           return _coffeeDrinkServiceResolver(coffeeType).Create(_coffeeUnits);
        }
    }
}
