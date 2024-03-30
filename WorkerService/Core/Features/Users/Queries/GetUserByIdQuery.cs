using Api.Users;
using MediatR;

namespace WorkerService.Core.Features.Users.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public long Id { get; set; }
        public GetUserByIdQuery(long id) 
        {
            Id = id;
        }
    }
}
