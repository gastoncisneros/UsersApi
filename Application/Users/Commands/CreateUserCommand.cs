using MediatR;

public class CreateUserCommand : IRequest<User> 
{
    public string UserName {get; set;}
    public string Email {get; set;}
    public string Password {get; set;}
}