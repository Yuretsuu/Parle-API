namespace Parle.Domain;

public class Ingredient : Entity
{
    public string Name { get; }
    
    public Ingredient(string name) : base(Guid.NewGuid(), DateTime.UtcNow)
    {
        Name = name;
    }
    
    public Ingredient(string name, Guid id, DateTime created) : base(id, created)
    {
        Name = name;
    }
}