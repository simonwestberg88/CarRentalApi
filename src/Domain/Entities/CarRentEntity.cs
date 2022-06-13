using CarRenting.Domain.Enums;

namespace CarRenting.Domain.Entities;

public class CarRentEntity
{
    public int Id { get; set; }
    public DateTime RentStart { get; set; }
    public DateTime? RentEnd { get; set; }
    public int MeterStart { get; set; }
    public int? MeterEnd { get; set; }
    public CustomerId CustomerId { get; set; }
    public CarCategory CarCategory { get; set; }
    public string LicenceNumber { get; set; }
    public int Meter { get; set; }
}

public class CustomerId
{
    public string IdNumber { get; set; }
    public IdType IdType { get; set; }
}