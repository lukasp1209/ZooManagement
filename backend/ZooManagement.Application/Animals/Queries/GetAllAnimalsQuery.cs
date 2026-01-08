using ZooManagement.Application.Animals.DTOs;
using ZooManagement.Application.Interfaces;

namespace ZooManagement.Application.Animals.Queries;

public class GetAllAnimalsQuery
{
    private readonly IAnimalRepository _repository;

    public GetAllAnimalsQuery(IAnimalRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<AnimalDto>> ExecuteAsync()
    {
        var animals = await _repository.GetAllAsync();

        return animals.Select(a => new AnimalDto
        {
            Id = a.Id,
            Name = a.Name,
            Species = a.Species.ToString(),
            Age = a.GetAge(),
            IsEndangered = a.IsEndangered
        }).ToList();
    }
}