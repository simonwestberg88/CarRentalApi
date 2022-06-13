namespace Application.Interfaces;

public interface IPriceService
{
    public decimal PricePerDay();
    public decimal PricePerKm();
}