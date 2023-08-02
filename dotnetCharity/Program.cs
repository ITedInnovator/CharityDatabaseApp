using Dapper;
using dotnet_charity_db;
using Npgsql;
using Npgsql.Replication.PgOutput.Messages;


var builder = WebApplication.CreateBuilder(args);

var ConnectionString = builder.Configuration["ConnectionString"];

// Add services to the container.
builder.Services.AddRazorPages();

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

var app = builder.Build();

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

app.Run();
