using Domain.MessageBus.Connection;

namespace Application.MessageBus.Connection
{
    public interface IConfiguration
    {
        IAddress Address { get; set; }
    }
}
