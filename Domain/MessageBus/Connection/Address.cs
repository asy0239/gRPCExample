namespace Domain.MessageBus.Connection
{
    public class Address : IAddress
    {
        public string HostName { get; }
        public string Port { get; }
        public Address(string hostName, string port)
        {
            HostName = hostName;
            Port = port;
        }
    }
}
