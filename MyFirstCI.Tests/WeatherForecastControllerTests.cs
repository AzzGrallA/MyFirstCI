using Xunit;
using MyFirstCI.Api.Controllers;

namespace MyFirstCI.Tests;

public class WeatherForecastControllerTests
{
    [Fact]
    public void AllForecastsInFuture()
    {
        // Arrange
        var controller = new WeatherController();

        // Act
        var result = controller.Get();

        // Assert
        foreach (var forecast in result)
            Assert.True(forecast.Date >= DateOnly.FromDateTime(DateTime.Now));
    }

    [Fact]
    public void Get_ReturnsFiveForecasts()
    {
        // Arrange
        var controller = new WeatherController();

        // Act
        var result = controller.Get();

        // Assert
        Assert.Equal(5, result.Count());
    }
}