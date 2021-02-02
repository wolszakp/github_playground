using Microsoft.Extensions.Logging;
using Moq;
using Pw.PlaygroundApi.Controllers;
using Xunit;

namespace Pw.PlaygroundApi.Test
{
    public class WeatherForecastControllerTests
    {
        private readonly WeatherForecastController _controller;

        public WeatherForecastControllerTests()
        {
            var logger = new Mock<ILogger<WeatherForecastController>>();
            _controller = new WeatherForecastController(logger.Object);
        }

        [Fact]
        public void WhenGetIsCalled_ItShouldReturnCurrentWeatherForecast()
        {
            var result = _controller.Get();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void WhenGetIsCalled_TemperatureShouldBeInRange_MinusTwentyToFiftyFive()
        {
            var result = _controller.Get();
            
            Assert.All(result, wf => Assert.True(wf.TemperatureC >= -20 && wf.TemperatureC <= 55));
        }
    }
}
