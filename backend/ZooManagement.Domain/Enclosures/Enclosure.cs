using ZooManagement.Domain.Animals;
using ZooManagement.Domain.Common;

namespace ZooManagement.Domain.Enclosures;

public class Enclosure : Entity
{
    private readonly List<Animal> _animals = new();

    public string Name { get; private set; }
    public EnclosureType Type { get; private set; }

    public IReadOnlyCollection<Animal> Animals => _animals.AsReadOnly();

    protected Enclosure() { }

    public Enclosure(Guid id, string name, EnclosureType type)
        : base(id)
    {
        Name = name;
        Type = type;
    }

    public void AddAnimal(Animal animal)
    {
        if (_animals.Contains(animal))
            throw new DomainException("Animal is already in this enclosure.");

        _animals.Add(animal);
    }

    public void RemoveAnimal(Animal animal)
    {
        _animals.Remove(animal);
    }
}