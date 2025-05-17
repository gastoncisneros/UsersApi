using MediatR;
using Microsoft.AspNetCore.Mvc;

public static class CommandRoutes 
{
    public static void MapCommandRoutes(this WebApplication application)
    {
        RouteGroupBuilder basePath = application.MapGroup("/api/users");

        basePath.MapPost("/", async (IMediator mediator, [FromBody] UserDTO userDTO) =>
        {
            CreateUserCommand createUserCommand = new CreateUserCommand() 
            { 
                UserName = userDTO.UserName,
                Email = userDTO.Email,
                Password = userDTO.Password
            };

            User newUser = await mediator.Send(createUserCommand);

            return Results.CreatedAtRoute("GetUserById", new {newUser.Id}, newUser);
        });

        basePath.MapPut("/{id}", async (IMediator mediator, [FromBody] UserDTO userDTO, [FromRoute] Guid id) =>
        {
            UpdateUserCommand updateUserCommand = new UpdateUserCommand() { UserId = id, userDTO = userDTO };
            User updatedUser = await mediator.Send(updateUserCommand);

            return Results.Ok(updatedUser);
        });

        basePath.MapDelete("/{id}", async (IMediator mediator, [FromRoute] Guid id) =>
        {
            DeleteUserCommand deleteUserCommand = new DeleteUserCommand() { UserId = id };
            await mediator.Send(deleteUserCommand);

            return Results.NoContent();
        });
    }
}