public static class CommandRoutes 
{
    public static void MapCommandRountes(this WebApplication application)
    {
        RouteGroupBuilder basePath = application.MapGroup("");
    }
}