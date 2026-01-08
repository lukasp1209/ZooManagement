using ZooManagement.Domain.Common;

namespace ZooManagement.Domain.Animals;

public class Animal : Entity
{
    public string Name { get; private set; }
    public Species Species { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public bool IsEndangered { get; private set; }

    protected Animal() { }

    public Animal(
        Guid id,
        string name,
        Species species,
        DateTime dateOfBirth,
        bool isEndangered = false)
        : base(id)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Animal name must not be empty.");

        Name = name;
        Species = species;
        DateOfBirth = dateOfBirth;
        IsEndangered = isEndangered;
    }

    public int GetAge()
    {
        var age = DateTime.Today.Year - DateOfBirth.Year;
        if (DateOfBirth.Date > DateTime.Today.AddYears(-age))
            age--;

        return age;
    }

    public void MarkAsEndangered()
    {
        IsEndangered = true;
    }
}