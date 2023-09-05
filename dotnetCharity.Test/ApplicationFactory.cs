using dotnet_charity_db.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Data.Common;
using Npgsql;

namespace dotnetCharity.Test
{
    public class ApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            var ConnectionString = "Host=localhost;Username=anthonychurch;Password=password;Database=charityDB_Test";
            builder.ConfigureServices(services => {
                services.AddNpgsqlDataSource(ConnectionString);
                services.AddScoped<IDbService, DbService>();
                services.AddScoped<ICharityService, CharityService>();
            });

            builder.UseEnvironment("test");
        }
    }
}
