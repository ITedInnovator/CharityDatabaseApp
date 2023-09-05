using dotnet_charity_db.Services;
using System;

public static class Api
{
    private const string Key = "dbSettings:tableName";

    public static void ConfigureApi(this WebApplication app)
    {
        app.MapGet("/api/charities", GetCharities);
    }

    private static async Task<IResult> GetCharities(ICharityService service, IConfiguration _config)
    {
        try
        {
            if(_config == null) throw new ArgumentNullException("config");
            var tableName = _config.GetValue<string>(Key);
            IEnumerable<dotnet_charity_db.Models.Charity> charities = await service.GetCharities(tableName);

            return Results.Ok(new { all = charities, database = tableName });
        }
        catch(Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
