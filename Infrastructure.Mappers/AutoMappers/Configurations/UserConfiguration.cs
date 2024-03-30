using AutoMapper;
using EntityUser = Domain.Entities.User;
using DtoUser = Api.Users.User;

namespace Infrastructure.Mappers.AutoMappers.Configurations
{
    public static class UserConfiguration
    {
        public static IMapperConfigurationExpression AddUser(this IMapperConfigurationExpression userConfiguration)
        {
            userConfiguration.CreateMap<EntityUser, DtoUser>().ReverseMap();
            return userConfiguration;
        }
    }
}
