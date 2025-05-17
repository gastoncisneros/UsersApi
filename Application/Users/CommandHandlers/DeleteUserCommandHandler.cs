using MediatR;

public class DeleteUserCommandHandler(IUsersRepository usersRepository) : IRequestHandler<DeleteUserCommand>
{
    private readonly IUsersRepository _usersRepository = usersRepository;

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await _usersRepository.DeleteUser(request.UserId);
    }
}