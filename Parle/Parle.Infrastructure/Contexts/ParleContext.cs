using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Sqlite;
using Parle.Domain;

namespace Parle.Infrastructure.Context;

//Handles designing the database
public class ParleContext : DbContext
{
    private readonly IConfiguration _configuration;
    
    //Defining the property of items (maps to a db table)
    public DbSet<MenuItem> MenuItems { get; set; }
    
    public ParleContext(IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration, nameof(configuration));

        _configuration = configuration;
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<MenuItem>()
            .HasData(
                new("Menu item 1"),
                new("Menu item 2"),
                new("Menu item 3"),
                new("Menu item 4"),
                new("Menu item 5")
            );
    }

    //Configures database
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var connectionString = _configuration.GetConnectionString("SqlLite");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException($"Invalid connection string. Connection string {connectionString}");
        }
        //TODO Look into what options are avail for sqlite
        optionsBuilder.UseSqlite(connectionString);
    }

}