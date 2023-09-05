   using dotnet_charity_db.Models;

   namespace dotnet_charity_db.Services;
   public interface ICharityService {
      public Task<IEnumerable<Charity>> GetCharities(string tableName);

    // Task<IEnumerable<Charity>> GetCharity(int id);

    // Task<int> AddCharity(string sql, object parameters);
}