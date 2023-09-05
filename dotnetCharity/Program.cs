using Dapper;
using dotnet_charity_db;
using dotnet_charity_db.Models;
using dotnet_charity_db.Services;
using Newtonsoft.Json;
using Npgsql;
using Npgsql.Replication.PgOutput.Messages;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using dotnet_charity_db.Startup;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    var ConnectionString = builder.Configuration["ConnectionString"];
builder.Services.AddNpgsqlDataSource(ConnectionString);

await using var dataSource = NpgsqlDataSource.Create(ConnectionString);

await using var connection = await dataSource.OpenConnectionAsync();


    await using var batch = new NpgsqlBatch(connection)
    {
        BatchCommands = {

        new("TRUNCATE TABLE charities;"),
        new ("INSERT INTO charities VALUES( DEFAULT, 'Sainted Boots', 'A charity about boots','346 Boots Street','','','Freetown', 'PG576R');"),
        new ("INSERT INTO charities VALUES( DEFAULT, 'Childrens Charity', 'A charity supporting children with disabilities','346 help street','','','Freetown', 'PG578G');")
        }
    };
    await batch.ExecuteNonQueryAsync();

    IDbService dbService = new DbService(connection);
}
else if(builder.Environment.Equals("test"))
{
    var ConnectionString = builder.Configuration["TestConnectionString"];
    IServiceCollection serviceCollection = builder.Services.AddNpgsqlDataSource(ConnectionString);
}



// Add services to the container.

builder.Services.RegisterServices();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();



Api.ConfigureApi(app);

app.Run();

public partial class Program { }