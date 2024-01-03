using RabbitMqExampleApi.Data;
using RabbitMqExampleApi.Models;

namespace RabbitMqExampleApi.Services;

public class EntityService : IEntityService
{
    private readonly DbContextClass _dbContext;
    
    public EntityService(DbContextClass dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IEnumerable<Entity> GetEntityList()
    {
        return _dbContext.Entities.ToList();
    }

    public Entity GetEntityById(int id)
    {
        return _dbContext.Entities.FirstOrDefault(x => x.Id == id);
    }

    public Entity AddEntity(Entity entity)
    {
        var result = _dbContext.Entities.Add(entity);
        _dbContext.SaveChanges();
        return result.Entity;
    }

    public Entity UpdateEntity(Entity entity)
    {
        var result = _dbContext.Entities.Update(entity);
        _dbContext.SaveChanges();
        return result.Entity;
    }

    public bool DeleteEntity(int Id)
    {
        var entity = _dbContext.Entities.Where(x => x.Id == Id).FirstOrDefault();
        if (entity == null)
        {
            return false;
        }
        
        var result = _dbContext.Entities.Remove(entity);
        _dbContext.SaveChanges();

        return result != null ? true : false;
    }
}