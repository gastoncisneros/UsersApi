using MediatR;

public class GetUserByIdQueryHandler(IUsersRepository usersRepository) : IRequestHandler<GetUserByIdQuery, User>
{
    private readonly IUsersRepository _usersRepository = usersRepository;

    public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return await _usersRepository.GetUserById(request.UserId);
    }
}