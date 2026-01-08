using ZooManagement.Domain.Animals;
using ZooManagement.Domain.Common;

namespace ZooManagement.Domain.Feedings;

public class FeedingSchedule : Entity
{
    public Animal Animal { get; private set; }
    public FoodType FoodType { get; private set; }
    public TimeSpan FeedingTime { get; private set; }

    protected FeedingSchedule() { }

    public FeedingSchedule(
        Guid id,
        Animal animal,
        FoodType foodType,
        TimeSpan feedingTime)
        : base(id)
    {
        Animal = animal;
        FoodType = foodType;
        FeedingTime = feedingTime;
    }
}