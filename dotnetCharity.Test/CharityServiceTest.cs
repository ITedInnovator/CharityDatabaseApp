using System.Buffers;
using System.Net.Http;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using FakeItEasy;

namespace dotnetCharity.Test;

[TestFixture, Description("CharityService")]
public class CharityServiceTest : DbSetupBase {
    // private readonly HttpClient _client;

    [Test, Description("Get all charities")]
    public async Task GetCharities(){
        //Arrange
        var application = new Application();
        HttpClient client = application.CreateClient();
        
        //Act
        var response = await client.GetAsync("/");
        //Assert
        TestContext.Out.WriteLine($"This is the response: {response.Content.ReadAsStringAsync().Result}");
        response.EnsureSuccessStatusCode();
        // Assert.That(response.Content, Has.Property("charityname"));
        Assert.That(response.Content, Is.Empty);

    }

}

