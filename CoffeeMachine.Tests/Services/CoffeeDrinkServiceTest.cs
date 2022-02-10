using CoffeeMachine.ApplicationLogic;
using CoffeeMachine.ApplicationLogic.Entities.Interfaces;
using CoffeeMachine.ApplicationLogic.Services;
using CoffeeMachine.Common.Helpers;
using Moq;
using NUnit.Framework;
using System;

namespace CoffeeMachine.Tests.Services
{
    public  class CoffeeDrinkServiceTest
    {
        private CoffeeDrinkService _coffeeDrinkService;
        private Mock<IAppSettingsHelper> _appSettingsHelper;

        private ICoffeeUnitEntity _coffeeUnitEntity;

        private int reqiuredBeans = 2;
        private int reqiuredMilk = 1;

        [SetUp]
        public void Setup()
        {
            _coffeeUnitEntity = new CoffeeUnitEntity();

            _appSettingsHelper = new Mock<IAppSettingsHelper>();
            _appSettingsHelper.Setup(repo => repo.GetCoffeeRequiredBeans())
                .Returns(reqiuredBeans);
            _appSettingsHelper.Setup(repo => repo.GetCoffeeRequiredMilk())
                .Returns(reqiuredMilk);

            _coffeeDrinkService = new CoffeeDrinkService(_appSettingsHelper.Object);
        }

        [Test]
        public void Create_Returns()
        {
            var expectedBeans = 13;
            var expectedMilk = 9;

            _coffeeUnitEntity.Beans = 15;
            _coffeeUnitEntity.Milk = 10;

            var result = _coffeeDrinkService.Create(_coffeeUnitEntity);

            Assert.AreEqual(expectedBeans, result.Beans);
            Assert.AreEqual(expectedMilk, result.Milk);
        }

        [Test]
        public void Create_LowMilk_Returns()
        {
            _coffeeUnitEntity.Beans = 3;
            _coffeeUnitEntity.Milk = 0;

            Assert.Throws<ApplicationException>(() => _coffeeDrinkService.Create(_coffeeUnitEntity));
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
