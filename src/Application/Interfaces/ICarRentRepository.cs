using CarRenting.Domain.Entities;
using CarRenting.Domain.Enums;

namespace Application.Interfaces;

public interface ICarRentRepository
{
    public Task<int> AddRentedCarAsync(DateTime rentStart, CarCategory carCategory, string licenceNumber,
        int meterReading, string idNumber, IdType idType);
    public Task ReturnRentedCarAsync(int bookingNumber, DateTime returnDate, int meterEnd);
    public CarRentEntity GetRentedCar(int bookingNumber);
}