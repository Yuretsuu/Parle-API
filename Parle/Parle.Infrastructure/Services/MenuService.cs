using Parle.Domain;
using Parle.Domain.Services;
using Parle.Infrastructure.Context;

namespace Parle.Infrastructure.Services;

public class MenuService : IMenuService
{
    private readonly ParleContext _parleContext;

    public MenuService(ParleContext parleContext)
    {
        ArgumentNullException.ThrowIfNull(parleContext, nameof(parleContext));
        _parleContext = parleContext;
    }
    
    public IEnumerable<MenuItem> FindAll()
    {
        var menuItems = _parleContext.MenuItems
            .ToList();
        
        return menuItems;
    }

    //An alternative is:
    /*if (menuItem == null)
    {
        throw new ArgumentNullException(nameof(menuItem));
    }*/
    public Guid Create(MenuItem menuItem)
    {
        ArgumentNullException.ThrowIfNull(menuItem, nameof(MenuItem));
        //Add to database table
        var record = _parleContext.MenuItems.Add(menuItem);
        //Save to database
        _parleContext.SaveChanges();
        //Generate Id
        return record.Entity.Id;
    }
}