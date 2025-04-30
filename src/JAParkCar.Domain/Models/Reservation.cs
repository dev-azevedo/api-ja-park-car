namespace JAParkCar.Domain.Models;

public class Reservation : BaseModel
{
    public Guid CarId { get; set; }
    public Guid CarSpaceId { get; set; }
    public DateTime InHour { get; set; }
    public DateTime OutHour { get; set; }
    public decimal PaymentValue { get;  set; }
    
    public required Car Car { get; set; }
    public required CarSpace CarSpace { get; set; }
}