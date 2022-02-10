using CoffeeMachine.ApplicationLogic.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine.ApplicationLogic
{
    public class CoffeeUnitEntity : ICoffeeUnitEntity
    {
        public int Beans { get; set; }
        public int Milk { get; set; }
    }
}
