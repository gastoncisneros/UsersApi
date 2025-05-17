using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using MediatR;

public class CreateUserCommandHandler(IUsersRepository usersRepository) : IRequestHandler<CreateUserCommand, User>
{
    private readonly IUsersRepository _usersRepository = usersRepository;

    public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        User newUser = new User
        {
            Username = request.UserName,
            Email = request.Email,
            PasswordHash = request.Password
        };

        return await _usersRepository.CreateUser(newUser);
    }
}