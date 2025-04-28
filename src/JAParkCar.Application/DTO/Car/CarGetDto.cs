namespace JAParkCar.Application.DTO.Car;

public class CarGetDto
{
    public required Guid Id { get; set; }
    public required string Brand { get; set; }
    public required string Model { get; set; }
    public required string Color { get; set; }
    public required string CarPlate { get; set; }
}