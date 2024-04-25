using Application.MessageBus.Connection;
using Domain.MessageBus.Connection;

namespace RabbitMQLibrary
{
    public class RabbitMQOptions
    {
        public Address? Address { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
