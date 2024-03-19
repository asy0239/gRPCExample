using gRPCServer.Services;

namespace gRPCServer.Extensions
{
    public static class ServiceExtension
    {
        public static IEndpointRouteBuilder AddControllers(this IEndpointRouteBuilder builder)
        {
            builder.MapGrpcService<UserService>();
            builder.MapGrpcService<GreeterService>();
            return builder;
        }
    }
}
