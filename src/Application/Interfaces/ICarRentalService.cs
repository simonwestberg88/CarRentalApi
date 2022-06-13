using Application.Contracts;

namespace Application.Interfaces;

public interface ICarRentalService
{
    public Task<int> RentCar(string licenceNumber, CarCategory carCategory, int meterReading, string idNumber,
        IdType idType, DateTime rentStart);

    public Task<decimal> ReturnCar(int bookingNumber, DateTime returnDate, int meterReading);
}