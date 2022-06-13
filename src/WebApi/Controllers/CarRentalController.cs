using Application.Contracts;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CarRentalController : ControllerBase
{
    private readonly ILogger<CarRentalController> _logger;
    private readonly ICarRentalService _carRentalService;

    public CarRentalController(ILogger<CarRentalController> logger, ICarRentalService carRentalService)
    {
        _logger = logger;
        _carRentalService = carRentalService;
    }

    [HttpPost("Rent")]
    public async Task<RentCarResponse> RentCar(RentCarRequest request)
    {
        //make it idempotent
        //Handle errors
        var bookingNumber = await _carRentalService.RentCar(request.LicencePlate, request.CarCategory,
            request.MeterReading, request.Customer.IdentityNumber, request.Customer.IdType, request.RentStart);
        return new RentCarResponse
        {
            BookingNumber = bookingNumber
        };
    }

    [HttpPost("Return")]
    public async Task<ReturnCarResponse> ReturnCar(ReturnCarRequest carRequest)
    {
        //make it idempotent
        //Handle errors
        var cost = await _carRentalService.ReturnCar(carRequest.BookingNumber, carRequest.ReturnDate, carRequest.MeterReading);
        return new ReturnCarResponse
        {
            Cost = cost
        };
    }
}