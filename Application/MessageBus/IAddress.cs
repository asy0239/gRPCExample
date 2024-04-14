namespace Application.MessageBus.Connection
{
    public interface IAddress
    {
        string HostName { get; }
        string Port { get; }
    }
}
