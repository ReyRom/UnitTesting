using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingLib.Library;
using TestingLib.Shop;
using TestingLib.Weather;

namespace UnitTesting
{
    public class LabWork7Test
    {
        private readonly Mock<IWeatherForecastSource> mockIWeatherForecastSource;
        private readonly Mock<ICustomerRepository> mockICustomerRepository;
        private readonly Mock<INotificationService> mockINotificationService;
        private readonly Mock<IOrderRepository> mockIOrderRepository;

        public LabWork7Test()
        {
            mockIWeatherForecastSource = new Mock<IWeatherForecastSource>();
            mockICustomerRepository = new Mock<ICustomerRepository>();
            mockINotificationService = new Mock<INotificationService>();
            mockIOrderRepository = new Mock<IOrderRepository>();
        }

        [Fact]
        public void GetWeatherForecast_ShouldReturnWeatherInToDay()
        {
            // Arrange

            var weatherForecast = new WeatherForecast() { Date = DateTime.Today, TemperatureC = 22, Summary = "Облачно, возможны осадки в виде фрикаделек"};

            mockIWeatherForecastSource.Setup(src => src.GetForecast(DateTime.Today)).Returns(weatherForecast);

            var service = new WeatherForecastService(mockIWeatherForecastSource.Object);

            // Act
            var result = service.GetWeatherForecast(DateTime.Today);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GeCustomerInfo_ShouldRetunCorrectInfo()
        {
            //Arrange
            var customer = new Customer {Id = 1, Name = "Andrey", Email = "AndMar"};
            var order = new Order {Id = 1, Date = DateTime.Today, Customer = customer, Amount = 1};
            mockIOrderRepository.Setup(repo => repo.GetOrders()).Returns(new List<Order> { new Order(), new Order() });
            mockICustomerRepository.Setup(repo => repo.GetCustomerById(1)).Returns(customer);

            var sevice = new ShopService(mockICustomerRepository.Object, mockIOrderRepository.Object, mockINotificationService.Object);

            //Act
            string result = service.GetCustomerInfo(1);

            //Assert
            Assert.NotNull(result);

        }
    }
}