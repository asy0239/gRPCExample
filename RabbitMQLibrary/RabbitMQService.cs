using Application.Persistences;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

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
            _channel.ExchangeDeclare(type: "topic",
                                    durable: false,
                                    exchange: "test",
                                    autoDelete: false,
                                    arguments:null);
            message = "hellow Mirero";

            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange:"test",
                                  routingKey: "testRoute",
                                  basicProperties: null,
                                  body: body);
            return Task.FromResult("Publish 완료 !! 내용 : " + message);
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
