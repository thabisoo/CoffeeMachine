using CoffeeMachine.ApplicationLogic.Entities.Interfaces;
using CoffeeMachine.ApplicationLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine.ApplicationLogic.Services.Interfaces
{
    public interface ICoffeeMachineService
    {
        ICoffeeUnitEntity Create(CoffeeType coffeeType);
    }
}
