using CoffeeMachine.ApplicationLogic;
using CoffeeMachine.ApplicationLogic.Entities.Interfaces;
using CoffeeMachine.ApplicationLogic.Services;
using CoffeeMachine.Common.Helpers;
using Moq;
using NUnit.Framework;
using System;

namespace CoffeeMachine.Tests.Services
{
    public class LatteDrinkServiceTest
    {
        private LatteDrinkService _latteDrinkService;
        private Mock<IAppSettingsHelper> _appSettingsHelper;

        private ICoffeeUnitEntity _coffeeUnitEntity;

        private int reqiuredBeans = 3;
        private int reqiuredMilk = 2;

        [SetUp]
        public void Setup()
        {
            _coffeeUnitEntity = new CoffeeUnitEntity();

            _appSettingsHelper = new Mock<IAppSettingsHelper>();
            _appSettingsHelper.Setup(repo => repo.GetLatteRequiredBeans())
                .Returns(reqiuredBeans);
            _appSettingsHelper.Setup(repo => repo.GetLatteRequiredMilk())
                .Returns(reqiuredMilk);

            _latteDrinkService = new LatteDrinkService(_appSettingsHelper.Object);
        }

        [Test]
        public void Create_Returns()
        {
            var expectedBeans = 12;
            var expectedMilk = 8;

            _coffeeUnitEntity.Beans = 15;
            _coffeeUnitEntity.Milk = 10;

            var result = _latteDrinkService.Create(_coffeeUnitEntity);

            Assert.AreEqual(expectedBeans, result.Beans);
            Assert.AreEqual(expectedMilk, result.Milk);
        }

        [Test]
        public void Create_LowMilk_Returns()
        {
            _coffeeUnitEntity.Beans = 15;
            _coffeeUnitEntity.Milk = 1;

            Assert.Throws<ApplicationException>(() => _latteDrinkService.Create(_coffeeUnitEntity));
        }

        [Test]
        public void Create_LowBeans_Returns()
        {
            _coffeeUnitEntity.Beans = 2;
            _coffeeUnitEntity.Milk = 7;

            Assert.Throws<ApplicationException>(() => _latteDrinkService.Create(_coffeeUnitEntity));
        }

        [Test]
        public void Create_Throws()
        {

            CoffeeUnitEntity coffeeUnitEntity = null;

            Assert.Throws<ArgumentNullException>(() => _latteDrinkService.Create(coffeeUnitEntity));
        }
    }
}
