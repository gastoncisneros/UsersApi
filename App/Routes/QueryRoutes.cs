using MediatR;
using Microsoft.AspNetCore.Mvc;

public static class QueryRoutes 
{
    public static void MapQueryRoutes(this WebApplication application)
    {
        RouteGroupBuilder basePath = application.MapGroup("/api/users");

        // Method inyection
        basePath.MapGet("/{id}", async (IMediator mediator, [FromRoute] string id) =>
        {
            Guid idGuid = Guid.Parse(id);
            GetUserByIdQuery getUserByIdQuery = new GetUserByIdQuery() { UserId = idGuid };
            User user = await mediator.Send(getUserByIdQuery);

            return TypedResults.Ok(user);
        })
        .WithName("GetUserById");

        basePath.MapGet("/", async (IMediator mediator) => 
        {
            GetAllUsersQuery getAllUsersQuery = new GetAllUsersQuery();
            IEnumerable<User> users = await mediator.Send(getAllUsersQuery);

            return TypedResults.Ok(users);
        })
        .WithName("GetAllUsers");
    }
}