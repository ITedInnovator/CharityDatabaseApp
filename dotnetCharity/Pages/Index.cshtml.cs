using Dapper;
using dotnet_charity_db.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Npgsql;

namespace dotnet_charity_db.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public NpgsqlConnection Connection;
    public IEnumerable<Charity>? Charities { get; private set; }

    public IndexModel(ILogger<IndexModel> logger, NpgsqlConnection connection)
    {
        _logger = logger;
        Connection = connection;
    }

    public async Task OnGet()
    {

       Charities = await GetCharities();
    }

    private async Task<IEnumerable<Charity>> GetCharities(){
        return await Connection.QueryAsync<Charity>( $"SELECT * FROM Charities;");
    }
}
