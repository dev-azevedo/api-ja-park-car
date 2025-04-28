namespace Domain.Models;

public class CarSpace
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required int NumberSpace { get; set; }
    public required bool Busy { get; set; } = false;
    public Guid? CarId { get; set; }
    
    public required Car Car { get; init; }
}