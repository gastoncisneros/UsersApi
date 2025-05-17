using MediatR;
using System.Linq;

public class UpdateUserCommandHandler(IUsersRepository usersRepository) : IRequestHandler<UpdateUserCommand, User>
{
    private readonly IUsersRepository _usersRepository = usersRepository;

    public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        User user = await _usersRepository.UpdateUser(request.UserId, request.userDTO);

        return user;
    }
}