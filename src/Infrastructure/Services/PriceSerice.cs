using Application.Interfaces;

namespace Infrastructure.Services;

public class PriceService: IPriceService
{
    public decimal PricePerDay()
    {
        //get price from some db / api
        return 100;
    }

    public decimal PricePerKm()
    {
        //get price from some db / api
        return 20;
    }
}