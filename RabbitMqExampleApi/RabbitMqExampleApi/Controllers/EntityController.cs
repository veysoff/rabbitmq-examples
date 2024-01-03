using Microsoft.AspNetCore.Mvc;
using RabbitMqExampleApi.Models;
using RabbitMqExampleApi.RabbitMq;
using RabbitMqExampleApi.Services;

namespace RabbitMqExampleApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EntityController : ControllerBase
{
    private readonly IEntityService _entityService;
    private readonly IRabbitMqProducer _rabbitMqProducer;
    
    public EntityController(IEntityService entityService, IRabbitMqProducer rabbitMqProducer)
    {
        _entityService = entityService;
        _rabbitMqProducer = rabbitMqProducer;
    }
    
    [HttpGet("entitylist")]
    public IEnumerable<Entity> ProductList()
    {
        var productList = _entityService.GetEntityList();
        return productList;
    }
    
    [HttpGet("getentitybyid")]
    public Entity GetProductById(int Id)
    {
        return _entityService.GetEntityById(Id);
    }
    
    [HttpPost("addentity")]
    public Entity AddProduct(Entity entity)
    {
        var entityData = _entityService.AddEntity(entity);
        
        //send the inserted product data to the queue and consumer will listening this data from queue
        _rabbitMqProducer.SendEntityMessage(entityData);
        
        return entityData;
    }
    
    [HttpPut("updateentity")]
    public Entity UpdateProduct(Entity entity)
    {
        return _entityService.UpdateEntity(entity);
    }
    
    [HttpDelete("deleteentity")]
    public bool DeleteProduct(int Id)
    {
        return _entityService.DeleteEntity(Id);
    }
}