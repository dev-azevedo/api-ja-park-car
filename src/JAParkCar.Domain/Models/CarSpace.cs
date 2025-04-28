namespace JAParkCar.Domain.Models;

public class CarSpace
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required int NumberSpace { get; set; }
    public required bool Busy { get; set; } = false;
    public  bool Active { get; set; } = true;
    
    public Reservation? Reservation { get; set; }
}