using DtoUser = Api.Users.User;
using EntityUesr = Domain.Entities.User;
using Application.Mappers;
using Application.Persistences;
using MediatR;
using WorkerService.Core.Features.Users.Commands;
using LanguageExt;

namespace WorkerService.Core.Features.Users.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, DtoUser>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public CreateUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<DtoUser> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<EntityUesr>(request.User);
            var newUser = await _userRepository.CreateUserAsync(entity, cancellationToken);
            var dtoUser = _mapper.Map<DtoUser>(newUser);
            return dtoUser;
        }
    }
}
