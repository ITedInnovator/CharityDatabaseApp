using Dapper;
using dotnet_charity_db.Models;
using dotnet_charity_db.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Npgsql;

namespace dotnet_charity_db.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    // public NpgsqlConnection Connection;
    public readonly ICharityService _charityService;
    public IEnumerable<Charity>? Charities { get; private set; }

    public IndexModel(ILogger<IndexModel> logger, ICharityService charityService)
    {
        _logger = logger;
        _charityService = charityService;
    }

    public async Task OnGet()
    {

       Charities = await _charityService.GetCharities("Charities");
    }

    // private async Task<IEnumerable<Charity>> GetCharities(){
        
    // }
}
