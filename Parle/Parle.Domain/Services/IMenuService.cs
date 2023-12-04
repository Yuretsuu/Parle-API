namespace Parle.Domain.Services;

public interface IMenuService
{
    //Enumerable is a concept of collection iteration (conveyor belt thing)
    IEnumerable<MenuItem> FindAll();

    Guid Create(MenuItem menuItem);
}