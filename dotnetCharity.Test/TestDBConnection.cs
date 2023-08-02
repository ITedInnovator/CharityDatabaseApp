using Microsoft.Extensions.Configuration.Json;
using Npgsql;

namespace dotnetCharity.Test;

public class TestDBConnection {
    public DatabaseFixture(){
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build();

        var testDB = new TestDatabaseBuilder().WithConfiguration(config).Build();

        testDB.Create();

        testDB.RunScripts("./migrations");
    }
}