namespace MinimalAPIDapper;

public static class API
{
    public static void ConfigureApi(this WebApplication app)
    {
        app.MapGet("/users", GetUsers);
        app.MapGet("/users/{id}", GetUser);
        app.MapPost("/users", InsertUser);
        app.MapPut("/users", UpdateUser);
        app.MapDelete("/users/{id}", DeleteUser);
    }

    private static async Task<IResult> GetUsers(IUserData userData)
    {
        try
        {
            var users = await userData.GetUsers();
            return Results.Ok(users);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> GetUser(int Id, IUserData userData)
    {
        try
        {
            var user = await userData.GetUser(Id);
            if (user is null)
                return Results.NotFound();
            return Results.Ok(user);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertUser(UserModel user, IUserData userData)
    {
        try
        {
            await userData.InsertUser(user);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateUser(UserModel user, IUserData userData)
    {
        try
        {
            await userData.Updateuser(user);
            return Results.NoContent();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteUser(int id, IUserData userData)
    {
        try
        {
            await userData.DeleteUser(id);
            return Results.NoContent();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
