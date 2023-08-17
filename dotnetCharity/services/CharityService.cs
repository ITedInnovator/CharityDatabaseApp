using dotnet_charity_db.Models;

namespace dotnet_charity_db.Services;

class CharityService : ICharityService {
    private readonly IDbService _dbService;

    public CharityService(IDbService dbService){
        _dbService = dbService;
    }

    public async Task<IEnumerable<Charity>> GetCharities(){
        return await _dbService.GetAll<Charity>( $"SELECT * FROM Charities;",new {});
    }
}