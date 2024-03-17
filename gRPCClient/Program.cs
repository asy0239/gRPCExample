using Grpc.Net.Client;

namespace gRPCClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5000");
            //var customerClient = new Customer.CustomerClient(channel);

            //var clientRequested = new CustomerLookupModel { UserId = 1 };

            //var customer = await customerClient.GetCustomerInfoAsync(clientRequested);


            //Console.WriteLine($"{customer.FirstName} {customer.LastName}");

            var greeterClient = new Greeter.GreeterClient(channel);

            var greeterRequested = new HelloRequest() { Name = "asyHello"};

            var reply = await greeterClient.SayHelloAsync(greeterRequested);

            Console.WriteLine(reply.Message);
            Console.ReadLine();
        }
    }
}