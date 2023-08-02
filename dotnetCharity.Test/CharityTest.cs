using System.Buffers;
using System.Net.Http;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;

namespace dotnetCharity.Test;

[TestFixture]
public class CharityTest {
    private readonly HttpClient _client;

[Test]
    public IntegrationTest(){
        var appFactory = new WebApplicationFactory<Startup>().WithWebHostBuilder( EnumBuilder => {
            services.RemoveAll(typeof(DataContext));
            services.AddDbContext<DataContext>( options => { options.UseInMemoryDatabase("TestDB");
            });
        });

        var TestClient = appFactory.CreateClient();
    }

    [Test]
    public async Task<string> GetCharity(){
        //Arrange
        var response = TestClient.Get
        //Act

        //Assert
    }

}

