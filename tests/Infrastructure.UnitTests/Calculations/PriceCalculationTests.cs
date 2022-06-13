using Application.Interfaces;
using CarRenting.Domain.Enums;
using Infrastructure.Services;
using Moq;

namespace Infrastructure.UnitTests.Calculations;

public class PriceCalculationTests
{
    private readonly IPriceCalculationService _priceCalculationService;
    private readonly Mock<IPriceService> _priceServiceMock;

    public PriceCalculationTests()
    {
        _priceServiceMock = new Mock<IPriceService>();
        _priceCalculationService = new PriceCalculationService(_priceServiceMock.Object);
    }

    [Theory, MemberData(nameof(PriceTestData))]
    public void PriceCalculation(int rentDays, int kilometers,
        CarCategory carCategory, decimal expectedPrice)
    {
        _priceServiceMock.Setup(x => x.PricePerDay()).Returns(100);
        _priceServiceMock.Setup(x => x.PricePerKm()).Returns(20);

        var price = _priceCalculationService.CalculateRentPrice(rentDays, kilometers,
            carCategory);

        price.Should().Be(expectedPrice);
    }

    public static IEnumerable<object[]> PriceTestData =>
        new List<object[]>
        {
            new object[] { 1, 123, CarCategory.SmallCar, 100 },
            new object[] { 2, 321, CarCategory.BigCar, 6680 },
            new object[] { 3, 213, CarCategory.Truck, 6840 },
            new object[] { 4, 500, CarCategory.BigCar, 10520 },
        };
}