namespace JAParkCar.Domain.Models;

public class Car
{ 
    public Guid Id { get; init; } = Guid.NewGuid();
    public required string Brand { get; set; } 
    public required string Model { get; set; }  
    public required string Color { get; set; }
    public required string CarPlate { get; set; }
    public  bool Active { get; set; } = true;
    
    public Reservation? Reservation { get; set; }
}