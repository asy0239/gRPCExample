using Application.MessageBus.Connection;
using RabbitMQ.Client;

namespace RabbitMQLibrary
{
    public interface IRabbitMQConfiguration : IConfiguration
    {
        ConnectionFactory GetConnectionFactory();
    }
}
