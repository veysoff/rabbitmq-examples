using Microsoft.EntityFrameworkCore;
using RabbitMqExampleApi.Models;

namespace RabbitMqExampleApi.Data;

public class DbContextClass : DbContext
{
    protected readonly IConfiguration Configuration;
    
    public DbContextClass(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
    }
    
    public DbSet<Entity> Entities { get; set; }
}