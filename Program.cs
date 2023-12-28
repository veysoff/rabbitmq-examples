using RabbitMQ_Example;

var client = new RabbitMqClient("localhost");

for (int i = 0; i < 5; i++)
{
    client.Send();
}

client.Receive();