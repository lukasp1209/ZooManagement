namespace ZooManagement.Application.Animals.DTOs;

public class AnimalDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Species { get; init; } = string.Empty;
    public int Age { get; init; }
    public bool IsEndangered { get; init; }
}