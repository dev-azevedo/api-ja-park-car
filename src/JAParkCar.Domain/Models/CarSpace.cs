namespace JAParkCar.Domain.Models;

public class CarSpace : BaseModel
{
    public required int NumberSpace { get; set; }
    public required bool Busy { get; set; } = false;
    
    public Reservation? Reservation { get; set; }
}