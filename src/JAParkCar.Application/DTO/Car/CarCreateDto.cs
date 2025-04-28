namespace JAParkCar.Application.DTO.Car;

public class CarCreateDto
{
    public required string Brand { get; set; }
    public required string Model { get; set; }
    public required string Color { get; set; }
    public required string CarPlate { get; set; }
}