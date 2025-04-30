namespace JAParkCar.Domain.Models;

public class Car : BaseModel
{ 
    public required string Brand { get; set; } 
    public required string Model { get; set; }  
    public required string Color { get; set; }
    public required string CarPlate { get; set; }
    
    public Reservation? Reservation { get; set; }
}