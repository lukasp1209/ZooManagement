using ZooManagement.Application.Animals.Commands;
using ZooManagement.Application.Animals.DTOs;
using ZooManagement.Application.Animals.Queries;
using ZooManagement.Application.Interfaces;
using ZooManagement.Domain.Animals;

namespace ZooManagement.Application.Animals.Services;

public class AnimalService
{
    private readonly IAnimalRepository _repository;

    public AnimalService(IAnimalRepository repository)
    {
        _repository = repository;
    }

    public Task<IReadOnlyList<AnimalDto>> GetAllAsync()
        => new GetAllAnimalsQuery(_repository).ExecuteAsync();

    public Task CreateAsync(string name, Species species, DateTime dateOfBirth)
        => new CreateAnimalCommand(_repository)
            .ExecuteAsync(name, species, dateOfBirth);
}