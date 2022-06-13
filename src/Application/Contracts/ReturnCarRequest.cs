namespace Application.Contracts;

public class ReturnCarRequest
{
    public int BookingNumber { get; set; }
    public DateTime ReturnDate { get; set; }
    public int MeterReading { get; set; }
}