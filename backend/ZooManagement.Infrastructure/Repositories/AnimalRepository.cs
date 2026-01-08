using Microsoft.EntityFrameworkCore;
using ZooManagement.Application.Interfaces;
using ZooManagement.Domain.Animals;
using ZooManagement.Infrastructure.Persistence;

namespace ZooManagement.Infrastructure.Repositories;

public class AnimalRepository : IAnimalRepository
{
    private readonly ZooDbContext _context;

    public AnimalRepository(ZooDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Animal>> GetAllAsync()
    {
        return await _context.Animals.AsNoTracking().ToListAsync();
    }

    public async Task AddAsync(Animal animal)
    {
        _context.Animals.Add(animal);
        await _context.SaveChangesAsync();
    }
}