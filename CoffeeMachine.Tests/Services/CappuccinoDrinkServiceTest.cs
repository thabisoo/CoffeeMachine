using CoffeeMachine.ApplicationLogic;
using CoffeeMachine.ApplicationLogic.Entities.Interfaces;
using CoffeeMachine.ApplicationLogic.Services;
using CoffeeMachine.Common.Helpers;
using Moq;
using NUnit.Framework;
using System;

namespace CoffeeMachine.Tests.Services
{
    public class CappuccinoDrinkServiceTest
    {
        private CappuccinoDrinkService _cappuccinoDrinkService;
        private Mock<IAppSettingsHelper> _appSettingsHelper;

        private ICoffeeUnitEntity _coffeeUnitEntity;

        private int reqiuredBeans = 5;
        private int reqiuredMilk= 3;

        [SetUp]
        public void Setup()
        {
            _coffeeUnitEntity = new CoffeeUnitEntity();

            _appSettingsHelper = new Mock<IAppSettingsHelper>();
            _appSettingsHelper.Setup(repo => repo.GetCappuccinoRequiredBeans())
                .Returns(reqiuredBeans);
            _appSettingsHelper.Setup(repo => repo.GetCappuccinoRequiredMilk())
                .Returns(reqiuredMilk);

            _cappuccinoDrinkService = new CappuccinoDrinkService(_appSettingsHelper.Object);
        }

        [Test]
        public void Create_Returns()
        {
            var expectedBeans = 10;
            var expectedMilk = 7;

            _coffeeUnitEntity.Beans = 15;
            _coffeeUnitEntity.Milk = 10;

            var result = _cappuccinoDrinkService.Create(_coffeeUnitEntity);

            Assert.AreEqual(expectedBeans, result.Beans);
            Assert.AreEqual(expectedMilk, result.Milk);
        }

        [Test]
        public void Create_LowMilk_Returns()
        {
            _coffeeUnitEntity.Beans = 15;
            _coffeeUnitEntity.Milk = 2;

            Assert.Throws<ApplicationException>(() => _cappuccinoDrinkService.Create(_coffeeUnitEntity));
        }

        [Test]
        public void Create_LowBeans_Returns()
        {
            _coffeeUnitEntity.Beans = 4;
            _coffeeUnitEntity.Milk = 7;

            Assert.Throws<ApplicationException>(() => _cappuccinoDrinkService.Create(_coffeeUnitEntity));
        }

        [Test]
        public void Create_Throws()
        {

            CoffeeUnitEntity coffeeUnitEntity = null;

            Assert.Throws<ArgumentNullException>(() => _cappuccinoDrinkService.Create(coffeeUnitEntity));
        }
    }
}
