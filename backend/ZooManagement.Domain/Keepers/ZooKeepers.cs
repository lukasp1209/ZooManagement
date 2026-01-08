using ZooManagement.Domain.Common;

namespace ZooManagement.Domain.Keepers;

public class Zookeeper : Entity
{
    public string Name { get; private set; }

    protected Zookeeper() { }

    public Zookeeper(Guid id, string name)
        : base(id)
    {
        Name = name;
    }
}