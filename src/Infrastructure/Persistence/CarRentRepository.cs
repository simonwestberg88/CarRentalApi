using Application.Interfaces;
using CarRenting.Domain.Entities;
using CarRenting.Domain.Enums;
using JsonFlatFileDataStore;

namespace Infrastructure.Persistence;

public class CarRentRepository : ICarRentRepository
{
    private IDocumentCollection<TEntity> GetCollection<TEntity>() where TEntity : class
    {
        var store = new DataStore("data.json");
        return store.GetCollection<TEntity>();
    }

    public async Task<int> AddRentedCarAsync(DateTime rentStart, CarCategory carCategory, string licenceNumber,
        int meterReading, string idNumber, IdType idType)
    {
        var collection = GetCollection<CarRentEntity>();
        var bookingNumber = (int)collection.GetNextIdValue();
        var carRent = new CarRentEntity
        {
            Id = bookingNumber,
            CarCategory = carCategory,
            LicenceNumber = licenceNumber,
            MeterStart = meterReading,
            CustomerId = new CustomerId { IdNumber = idNumber, IdType = idType },
            RentStart = rentStart
        };
        await collection.InsertOneAsync(carRent);
        return bookingNumber;
    }

    public async Task ReturnRentedCarAsync(int bookingNumber, DateTime returnDate, int meterEnd)
    {
        //handle when car not found
        var collection = GetCollection<CarRentEntity>();
        var car = collection.Find(c => c.Id == bookingNumber).FirstOrDefault();
        car.MeterEnd = meterEnd;
        car.RentEnd = returnDate;
        await collection.UpdateOneAsync(r => r.Id == bookingNumber, car);
    }

    public CarRentEntity GetRentedCar(int bookingNumber)
    {
        var collection = GetCollection<CarRentEntity>();
        return collection.Find(c => c.Id == bookingNumber).FirstOrDefault();
    }
}