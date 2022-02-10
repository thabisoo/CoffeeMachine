using CoffeeMachine.ApplicationLogic.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine.ApplicationLogic.Services.Interfaces
{
    public interface ICoffeeDrinkService
    {
        ICoffeeUnitEntity Create(ICoffeeUnitEntity coffeeUnits);
    }
}
