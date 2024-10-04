using Moq;
using TestingLib.Shop;
using TestingLib.Weather;

namespace UnitTesting.GSEvgenievich
{
    public class MoqTests
    {
        private readonly Mock<ICustomerRepository> mockCustomerRepository;
        private readonly Mock<IOrderRepository> mockOrderRepository;
        private readonly Mock<INotificationService> mockNotificationService;
        private readonly Mock<IWeatherForecastSource> mockWeatherForecastSource;
        public MoqTests()
        {
            mockCustomerRepository = new Mock<ICustomerRepository>();
            mockOrderRepository = new Mock<IOrderRepository>();
            mockNotificationService = new Mock<INotificationService>();
            mockWeatherForecastSource = new Mock<IWeatherForecastSource>();
        }

        [Fact]
        public void GetCustomerInfo_ShouldReturnCorrectInfo()
        {
            // Arrange
            var customer = new Customer { Id = 1, Name = "Petya", Email = "petya@yandex.ru" };

            mockCustomerRepository.Setup(repo => repo.GetCustomerById(1)).Returns(customer);
            mockOrderRepository.Setup(repo => repo.GetOrders()).Returns(new List<Order> { new Order() { Customer = customer }, new Order() { Customer = customer } });

            var service = new ShopService(mockCustomerRepository.Object, mockOrderRepository.Object, mockNotificationService.Object);

            // Act
            var result = service.GetCustomerInfo(1);

            // Assert
            Assert.Equal("Customer " + customer.Name + " has 2 orders", result);
            mockOrderRepository.Verify(repo => repo.GetOrders(), Times.Once);
            mockCustomerRepository.Verify(repo => repo.GetCustomerById(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void CreateOrder_ShouldAddOrder()
        {
            // Arrange
            var customer = new Customer { Id = 1, Name = "Petya", Email = "petya@yandex.ru" };
            var order = new Order { Id = 2, Date = DateTime.Now, Customer = customer, Amount = 3 };
            mockOrderRepository.Setup(repo => repo.GetOrderById(1)).Returns(order);

            var service = new ShopService(mockCustomerRepository.Object, mockOrderRepository.Object, mockNotificationService.Object);

            // Act
            service.CreateOrder(order);

            // Act и Assert
            mockOrderRepository.Verify(repo => repo.GetOrderById(It.IsAny<int>()), Times.Once);
            mockOrderRepository.Verify(repo => repo.AddOrder(It.IsAny<Order>()), Times.Once);
        }

        [Fact]
        public void CreateOrder_ShouldSendNotification()
        {
            // Arrange
            var customer = new Customer { Id = 1, Name = "Petya", Email = "petya@yandex.ru" };
            var order = new Order { Id = 2, Date = DateTime.Now, Customer = customer, Amount = 3 };
            mockOrderRepository.Setup(repo => repo.GetOrderById(1)).Returns(order);

            var service = new ShopService(mockCustomerRepository.Object, mockOrderRepository.Object, mockNotificationService.Object);

            // Act
            service.CreateOrder(order);

            // Act и Assert
            mockNotificationService.Verify(repo => repo.SendNotification(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void GetWeatherForecast_ShouldReturnCorrectInfo()
        {
            var weatherForecast = new WeatherForecast { Summary = "Yasno", TemperatureC = 23 };
            var currentTime = DateTime.Now;
            mockWeatherForecastSource.Setup(repo => repo.GetForecast(currentTime)).Returns(weatherForecast);

            var service = new WeatherForecastService(mockWeatherForecastSource.Object);

            //Act
            var result = service.GetWeatherForecast(currentTime);

            //Assert
            Assert.NotNull(result);
            mockWeatherForecastSource.Verify(repo => repo.GetForecast(It.IsAny<DateTime>()), Times.Once);
        }
    }
}


