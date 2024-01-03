using RabbitMqExampleApi.Models;

namespace RabbitMqExampleApi.Services;

public interface IEntityService
{
    public IEnumerable<Entity> GetEntityList();
    public Entity GetEntityById(int id);
    public Entity AddEntity(Entity entity);
    public Entity UpdateEntity(Entity entity);
    public bool DeleteEntity(int Id);
}