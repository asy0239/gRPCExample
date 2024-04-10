using Application.Option;
using Application.Persistences;
using Domain.Option;
using Domain.Resilience;
using Microsoft.Extensions.Logging;
using Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System.Text;

namespace RabbitMQLibrary
{
    public class RabbitMQService : IMessageQueue
    {
        private IRabbitMQConfiguration _configuration;
        private IConnection _connection;
        private IModel _channel;
        private ILogger _logger;
        private IOptional<MessageBusOption> _messageBus;
        private readonly RetryOption _retryOption;

        public RabbitMQService(IRabbitMQConfiguration configuration, ILogger logger, RetryOption retryOption, IOptional<MessageBusOption> options)
        {
            _configuration = configuration;
            _logger = logger;
            _retryOption = retryOption;
            _messageBus = options;

            (_connection, _channel) = Connection(() =>
            {
                ConnectionFactory factory = _configuration.GetConnectionFactory();
                var connection = factory.CreateConnection();
                var channel = connection.CreateModel();
                return (connection, channel);
            }, _retryOption);
        }

        private (IConnection, IModel) Connection(Func<(IConnection, IModel)> func, RetryOption retryOption)
        {
            return Policy.Handle<BrokerUnreachableException>()
                  .WaitAndRetry(
                      retryOption.RetryCount,
                      delay => TimeSpan.FromMilliseconds(retryOption.RetryDelayMilliseconds),
                      (ex, time) => {
                          _logger.LogError(ex, ex.Message);
                      })
                  .Execute(func);
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
