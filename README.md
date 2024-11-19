# UnitTesting

ИСПП-35
Фролова Мия, Луев Роман 

using System;
using TestingLib.Math;

namespace UnitTesting.amadesya
{
    public class Basic
    {
        private readonly BasicCalc _calculator;

        public Basic()
        {
            _calculator = new BasicCalc();
        }

        [Fact]
        public void SolveQuadraticEquation_ShouldReturnCorrectRoots()
        {
            (double?, double?) descriminant = _calculator.SolveQuadraticEquation(1.0, 2.0, -3.0);
            Assert.Equal(descriminant, descriminant);
        }

        [Theory]
        [InlineData(2.0, 3.0, -5.0, 1.0, -2.5)]
        public void SolveQuadraticEquation_Theory(double a, double b, double c, double? expectedResult1, double? expectedResult2)
        {
            var discriminant = _calculator.SolveQuadraticEquation(a, b, c);
            Assert.Equal(expectedResult1, discriminant.Item1);
            Assert.Equal(expectedResult2, discriminant.Item2);
        }

        [Theory]
        [InlineData(0, 3.0, -5.0)]
        public void SolveQuadraticEquation_Exeption(double a, double b, double c)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.SolveQuadraticEquation(a,b,c));
        }
    }
}


using Moq;
using TestingLib.Shop;

namespace UnitTesting.XUnit
{
    public class ShopTests
    {
        private readonly Mock<ICustomerRepository> mockCustomerRepository;
        private readonly Mock<IOrderRepository> mockOrderRepository;
        private readonly Mock<INotificationService> mockNotificationService;

        public ShopTests()
        {
            mockCustomerRepository = new Mock<ICustomerRepository>();
            mockOrderRepository = new Mock<IOrderRepository>();
            mockNotificationService = new Mock<INotificationService>();
        }

        [Fact]
        public void CreateOrder_WhenOrderIsCreated()
        {
            var customer = new Customer { Id = 1, Name = "Test User", Email = "example@gmail.com" };
            Order order = new Order { Id = 1, Date = new DateTime(2023, 09, 11), Customer = customer, Amount = 1 };

            var service = new ShopService(mockCustomerRepository.Object, mockOrderRepository.Object, mockNotificationService.Object);

            service.CreateOrder(order);

            mockOrderRepository.Verify(repo => repo.AddOrder(order), Times.Once);
            mockNotificationService.Verify(s => s.SendNotification(customer.Email, $"Order {order.Id} created for customer {order.Customer.Name} total price {order.Amount}"), Times.Once);
        }

        [Fact]
        public void CreateOrder_ShouldReturnFalse_WhenOrderIsNotCreated()
        {
            var customer = new Customer { Id = 1, Name = "Test User", Email = "example@gmail.com" };
            Order order = new Order { Id = 1, Date = new DateTime(2023, 09, 11), Customer = customer, Amount = 1 };

            var service = new ShopService(mockCustomerRepository.Object, mockOrderRepository.Object, mockNotificationService.Object);

            service.CreateOrder(order);

            Assert.Throws<ArgumentException>(() => service.CreateOrder(order));
        }

        [Fact]
        public void GetCustomerInfo_ShouldReturnCustomerInfo()
        {
            var customer = new Customer { Id = 1, Name = "Test User", Email = "example@gmail.com" };
            Order orders = new Order { Id = 1, Date = new DateTime(2023, 09, 11), Customer = customer, Amount = 1 };

            var service = new ShopService(mockCustomerRepository.Object, mockOrderRepository.Object, mockNotificationService.Object);
            service.CreateOrder(orders);

            service.GetCustomerInfo(1);

            mockCustomerRepository.Verify(repo => repo.GetCustomerById(1), Times.Once);
        }
    }
}

