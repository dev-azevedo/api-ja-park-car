namespace Domain.Models;

public class Car
{ 
    public Guid Id { get; init; } = Guid.NewGuid();
    public required string Brand { get; set; } 
    public required string Model { get; set; }  
    public required string Color { get; set; }
    public required string CarPlate { get; set; }   
    public DateTime InHour { get; private set; }
    public DateTime OutHour { get; private set; }
    public decimal PaymentValue { get; private set; }
    
    public CarSpace? CarSpace { get; set; }
}