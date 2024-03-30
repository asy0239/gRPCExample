using ICustomMapper = Application.Mappers.IMapper;
using AutoMapper;
using Infrastructure.Mappers.AutoMappers.Configurations;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Mappers.AutoMappers
{
    public static class AutoMapperExtension
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddSingleton<ICustomMapper, AutoMapperDI>();
            services.AddSingleton<IMapper>(new Mapper(MapperBuilder()));
            return services;
        }

        private static MapperConfiguration MapperBuilder()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateUser();
            });
        }
    }
}
