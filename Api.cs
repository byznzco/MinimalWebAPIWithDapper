using Microsoft.AspNetCore.Mvc;
using MinimalWebAPI.Queries;

public static class Api
{
    public static void ConfigureApi(this WebApplication app)
    {
        app.MapGet("/Users", GetUsers);
    }

    private static async Task<IResult> GetUsers(IUserData userData)
    {
        try
        {
            return Results.Ok(await userData.GetAllUsers(StoredProcedures.SP_SELECT_ALL_USERS));
        }
        catch(Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
