using Domain.MessageBus.Connection;
using RabbitMQ.Client;

namespace RabbitMQLibrary
{
    public class RabbitMQConfiguration : IRabbitMQConfiguration
    {
        public IAddress Address { get; set; }

        public RabbitMQConfiguration(IAddress address)
        {
            Address = address;
        }

        public ConnectionFactory GetConnectionFactory()
        {
            ConnectionFactory factory = new ConnectionFactory()
            {
                HostName = Address.HostName,
                Port = int.Parse(Address.Port),
                UserName = "mirero",
                Password = "system"
            };

            return factory;
        }
    }
}
