using ZooManagement.Application.Interfaces;
using ZooManagement.Domain.Animals;

namespace ZooManagement.Application.Animals.Commands;

public class CreateAnimalCommand
{
    private readonly IAnimalRepository _repository;

    public CreateAnimalCommand(IAnimalRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(
        string name,
        Species species,
        DateTime dateOfBirth)
    {
        var animal = new Animal(
            Guid.NewGuid(),
            name,
            species,
            dateOfBirth);

        await _repository.AddAsync(animal);
    }
}