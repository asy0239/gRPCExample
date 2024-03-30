using Api.Users;
using Application.Mappers;
using Application.Persistences;
using MediatR;
using WorkerService.Core.Features.Users.Queries;

namespace WorkerService.Core.Features.Users.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper; 
        public GetUserByIdHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _userRepository.GetUserAsync(request.Id);
            var dtoUser = _mapper.Map<User>(entity);
            return dtoUser;
        }
    }
}
