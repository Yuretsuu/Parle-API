namespace Parle.Domain;
//Immutable- Once the class has been instantiated, the values cannot be changed
public abstract class Entity
{
    public Guid Id { get; private set; }
    
    public DateTime Created { get; private set; }

    protected Entity(Guid id, DateTime created)
    {
        Id = id;
        Created = created;
    }

}
