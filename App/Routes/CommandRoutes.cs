public static class CommandRoutes 
{
    public static void MapCommandRoutes(this WebApplication application)
    {
        RouteGroupBuilder basePath = application.MapGroup("");
    }
}