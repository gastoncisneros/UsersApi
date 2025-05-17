using MediatR;

public class GetAllUsersQueryHandler(IUsersRepository usersRepository) : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
{
    private readonly IUsersRepository _usersRepository = usersRepository;

    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return await _usersRepository.GetAllUsers();
    }
}