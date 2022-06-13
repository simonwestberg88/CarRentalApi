using CarRenting.Domain.Enums;

namespace Application.Interfaces;

public interface IPriceCalculationService
{
    public decimal CalculateRentPrice(int rentDays, int kilometers,
        CarCategory carCategory);
}