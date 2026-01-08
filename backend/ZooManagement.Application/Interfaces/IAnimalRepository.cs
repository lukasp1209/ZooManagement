using ZooManagement.Domain.Animals;

namespace ZooManagement.Application.Interfaces;

public interface IAnimalRepository
{
    Task<IReadOnlyList<Animal>> GetAllAsync();
    Task AddAsync(Animal animal);
}