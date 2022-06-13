using Application.Interfaces;
using CarRenting.Domain.Enums;

namespace Infrastructure.Services;

public class PriceCalculationService : IPriceCalculationService
{
    private readonly IPriceService _priceService;

    public PriceCalculationService(IPriceService priceService)
    {
        _priceService = priceService;
    }

    public decimal CalculateRentPrice(int rentDays, int kilometers,
        CarCategory carCategory)
    {
        var pricePerDay = _priceService.PricePerDay();
        var pricePerKm = _priceService.PricePerKm();
        return carCategory switch
        {
            CarCategory.SmallCar => rentDays * pricePerDay,
            CarCategory.BigCar => rentDays * pricePerDay * 1.3M + pricePerKm * kilometers,
            CarCategory.Truck => rentDays * pricePerDay * 1.5M + pricePerKm * kilometers * 1.5M,
            _ => 0
        };
    }
}