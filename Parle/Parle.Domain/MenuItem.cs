namespace Parle.Domain;

public class MenuItem : Entity
{
    public string Name { get; private set; }
    
    public MenuItem(string name) : base(Guid.NewGuid(), DateTime.UtcNow)
    {
        Name = name;
    } 
    
    public MenuItem(string name,Guid id, DateTime created) : base(id, created)
    {
        Name = name;
    }
}