using Application.Contracts;
using Application.Exceptions;
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
    public async Task<IActionResult> RentCar(RentCarRequest request)
    {
        //make it idempotent
        //Handle errors
        //log errors
        try
        {
            var bookingNumber = await _carRentalService.RentCar(request.LicencePlate, request.CarCategory,
                request.MeterReading, request.Customer.IdentityNumber, request.Customer.IdType, request.RentStart);
            return Ok(new RentCarResponse
            {
                BookingNumber = bookingNumber
            });
        }
        catch (CarUnavailableException e)
        {
            return BadRequest(e.Message);
        }
        
    }

    [HttpPost("Return")]
    public async Task<IActionResult> ReturnCar(ReturnCarRequest carRequest)
    {
        try
        {
            var cost = await _carRentalService.ReturnCar(carRequest.BookingNumber, carRequest.ReturnDate,
                carRequest.MeterReading);
            return Ok(new ReturnCarResponse
            {
                Cost = cost
            });
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}