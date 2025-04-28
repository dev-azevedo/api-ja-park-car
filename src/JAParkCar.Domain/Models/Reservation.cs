namespace JAParkCar.Domain.Models;

public class Reservation
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid CarId { get; init; }
    public Guid CarSpaceId { get; init; }
    public DateTime InHour { get; set; }
    public DateTime OutHour { get; set; }
    public decimal PaymentValue { get;  set; }
    public bool Active { get; set; } = true;
    
    public required Car Car { get; set; }
    public required CarSpace CarSpace { get; set; }
}