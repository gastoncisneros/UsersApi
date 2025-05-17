using MediatR;

public class GetAllUsersQuery : IRequest<IEnumerable<User>>
{
}