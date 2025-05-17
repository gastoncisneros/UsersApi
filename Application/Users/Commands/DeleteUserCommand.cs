using MediatR;

public class DeleteUserCommand : IRequest
{
    public Guid UserId {get; set;}
}