using System.Data;
using Npgsql;
using Dapper;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Dataflow;

namespace dotnet_charity_db.Services;

class DbService : IDbService {

    private readonly IDbConnection _db;

    public DbService(NpgsqlConnection connection){
        _db = connection;
    }

public async Task<IEnumerable<T>> GetSingle<T>(string command, object parameters){
   return await _db.QueryAsync<T>(command, parameters).ConfigureAwait(false);
}

public async Task<IEnumerable<T>> GetAll<T>( string command, object parameters){
    return await _db.QueryAsync<T>(command, parameters).ConfigureAwait(false);
}

public async Task<int> Insert<T>(string command, object parameters){
    return await _db.ExecuteAsync(command, parameters).ConfigureAwait(false);
}

public async Task<int> Update<T>(string command, object parameters){
    return await _db.ExecuteAsync(command, parameters).ConfigureAwait(false);
}

public async Task<int> Delete<T>(string command, object parameters){
    return await _db.ExecuteAsync(command, parameters);
}

}