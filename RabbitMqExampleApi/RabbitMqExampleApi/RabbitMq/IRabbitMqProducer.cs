namespace RabbitMqExampleApi.RabbitMq;

public interface IRabbitMqProducer
{
    public void SendEntityMessage<T>(T message);
}