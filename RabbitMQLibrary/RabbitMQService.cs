using Application.Persistences;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQLibrary
{
    public class RabbitMQService : IMessageQueue
    {
        IRabbitMQConfiguration _configuration;
        IConnection _connection;
        IModel _channel;

        public RabbitMQService(IRabbitMQConfiguration configuration) 
        {
            _configuration = configuration;
            ConnectionFactory factory = _configuration.GetConnectionFactory();
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }
        public Task<string> ConsumeMessageAsync(string queueName)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetValueAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task PublishMessageAsync(string queueName, string message)
        {
            return 
        }

        public Task<bool> RemoveKeyAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task SetValueAsync(string key, string value)
        {
            throw new NotImplementedException();
        }
    }
}
