using CoffeeMachine.ApplicationLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine.ApplicationLogic.Entities.Interfaces
{
    public interface ICoffeeUnitEntity
    {
        public int Beans { get; set; }
        public int Milk { get; set; }
    }
}
