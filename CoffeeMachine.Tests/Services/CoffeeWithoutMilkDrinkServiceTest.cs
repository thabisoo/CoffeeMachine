using CoffeeMachine.ApplicationLogic;
using CoffeeMachine.ApplicationLogic.Entities.Interfaces;
using CoffeeMachine.ApplicationLogic.Services;
using CoffeeMachine.Common.Helpers;
using Moq;
using NUnit.Framework;
using System;

namespace CoffeeMachine.Tests.Services
{
    public class CoffeeWithoutMilkDrinkServiceTest
    {
        private CoffeeWithoutMilkDrinkService _coffeeDrinkService;
        private Mock<IAppSettingsHelper> _appSettingsHelper;

        private ICoffeeUnitEntity _coffeeUnitEntity;

        private int reqiuredBeans = 2;

        [SetUp]
        public void Setup()
        {
            _coffeeUnitEntity = new CoffeeUnitEntity();

            _appSettingsHelper = new Mock<IAppSettingsHelper>();
            _appSettingsHelper.Setup(repo => repo.GetCoffeeRequiredBeans())
                .Returns(reqiuredBeans);

            _coffeeDrinkService = new CoffeeWithoutMilkDrinkService(_appSettingsHelper.Object);
        }

        [Test]
        public void Create_Returns()
        {
            var expectedBeans = 13;

            _coffeeUnitEntity.Beans = 15;

            var result = _coffeeDrinkService.Create(_coffeeUnitEntity);

            Assert.AreEqual(expectedBeans, result.Beans);
        }

        [Test]
        public void Create_LowBeans_Returns()
        {
            _coffeeUnitEntity.Beans = 1;
            _coffeeUnitEntity.Milk = 3;

            Assert.Throws<ApplicationException>(() => _coffeeDrinkService.Create(_coffeeUnitEntity));
        }

        [Test]
        public void Create_Throws()
        {

            CoffeeUnitEntity coffeeUnitEntity = null;

            Assert.Throws<ArgumentNullException>(() => _coffeeDrinkService.Create(coffeeUnitEntity));
        }
    }
}
