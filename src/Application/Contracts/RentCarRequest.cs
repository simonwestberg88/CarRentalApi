namespace Application.Contracts;

public class RentCarRequest
{
    public string LicencePlate { get; set; }
    public CustomerIdentityDto Customer { get; set; }
    public DateTime RentStart { get; set; }
    public CarCategory CarCategory { get; set; }
    public int MeterReading { get; set; }
}