using MediatR;

public class UpdateUserCommand : IRequest<User>
{
    public Guid UserId {get; set;}
    public UserDTO userDTO {get;set;}
}