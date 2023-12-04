using Microsoft.AspNetCore.Mvc;
using Parle.Domain;
using Parle.Domain.Services;

namespace Parle.API.Controllers;
[ApiController]
[Route("[controller]")]
public class MenuController : ControllerBase
{
    private readonly IMenuService _menuService;

    public MenuController(IMenuService menuService)
    {
        ArgumentNullException.ThrowIfNull(menuService, nameof(menuService));
        _menuService = menuService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var menuItems = _menuService.FindAll();

        return Ok(menuItems);
    }

    //TODO Rocky can explain serialization later
    [HttpPost]
    public IActionResult Create(string name)
    {
        var id = _menuService.Create(new MenuItem(name));
        return Ok(id);
    }
    
}