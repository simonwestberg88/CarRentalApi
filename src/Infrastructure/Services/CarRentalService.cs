using Application.Contracts;
using Application.Interfaces;
using Infrastructure.CalculationHelpers;

namespace Infrastructure.Services;

public class CarRentalService : ICarRentalService
{
    private readonly ICarRentRepository _repository;
    private readonly IPriceCalculationService _priceCalculationService;
    private readonly IPriceService _priceService;

    public CarRentalService(ICarRentRepository repository,
        IPriceService priceService,
        IPriceCalculationService priceCalculationService)
    {
        _repository = repository;
        _priceService = priceService;
        _priceCalculationService = priceCalculationService;
    }

    public async Task<int> RentCar(string licenceNumber, CarCategory carCategory, int meterReading, string idNumber,
        IdType idType, DateTime rentStart)
    {
        return await _repository.AddRentedCarAsync(rentStart, (CarRenting.Domain.Enums.CarCategory)carCategory,
            licenceNumber, meterReading, idNumber, (CarRenting.Domain.Enums.IdType)idType);
    }

    public async Task<decimal> ReturnCar(int bookingNumber, DateTime returnDate, int meterReading)
    {
        //handle when no car is found
        await _repository.ReturnRentedCarAsync(bookingNumber, returnDate, meterReading);
        var car = _repository.GetRentedCar(bookingNumber);
        var rentDays = DateCalculations.CalculateDays(car.RentStart, returnDate);
        var distance = DistanceCalculations.Calculate(car.MeterStart, meterReading);
        var cost = _priceCalculationService.CalculateRentPrice(rentDays, distance, car.CarCategory);
        return cost;
    }
}