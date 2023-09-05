using dotnetCharity.Test;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Respawn;

namespace dotnetCharity.Test;

[TestFixture]
public class DatabaseSetup
{

    private IConfiguration _config; 
    private NpgsqlConnection _connection;
    public DatabaseSetup(NpgsqlConnection connection)
    {
        _connection = connection;
    }

    

    [SetUp]
    public async Task Init()
    {

        _config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.test.json")
        .AddEnvironmentVariables()
        .Build();

        string ConnectionString = _config["TestConnectionString"];


        await using var dataSource = NpgsqlDataSource.Create(ConnectionString);

        await using var connection = await dataSource.OpenConnectionAsync();

        await using var batch = new NpgsqlBatch(_connection)
    {
        BatchCommands = {

        new("TRUNCATE TABLE charities_test;"),
        new ("INSERT INTO charities_test VALUES( DEFAULT, 'Sainted Boots', 'A charity about boots','346 Boots Street','','','Freetown', 'PG576R');"),
        new ("INSERT INTO charities_test VALUES( DEFAULT, 'Childrens Charity', 'A charity supporting children with disabilities','346 help street','','','Freetown', 'PG578G');"),
        new ("INSERT INTO charities_test VALUES( DEFAULT, 'Dog Charity', 'A charity supporting dog shelters','349 help street','','','Freetown', 'PG578G');")
        }
    };
    await batch.ExecuteNonQueryAsync();
    }

    [TearDown]
    public async Task endtest()
    {
        if (_connection != null)
        {
        var respawner = await Respawner.CreateAsync(_connection, new RespawnerOptions
        {
            SchemasToInclude = new[]
    {
         "charities_test"
     },
            DbAdapter = DbAdapter.Postgres
        });    
        }
    }
}