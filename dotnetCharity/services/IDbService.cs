using System.Runtime.CompilerServices;

namespace dotnet_charity_db.Services;
public interface IDbService {
    Task<IEnumerable<T>> GetSingle<T>(string command, object parameters);
    Task<IEnumerable<T>> GetAll<T>(string command, object parameters);

    Task<int> Insert<T>(string command, object parameters);

    Task<int> Update<T>(string command, object parameters);
}