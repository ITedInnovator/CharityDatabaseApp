using System.Buffers;
using System.Net.Http;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using FakeItEasy;
using dotnet_charity_db.Models;
using AngleSharp.Html.Parser;
using Microsoft.AspNetCore.TestHost;
using ServiceStack;
using dotnet_charity_db.Services;
using Newtonsoft.Json;
using NUnit.Framework.Internal;

namespace dotnetCharity.Test;

[TestFixture, Description("CharityService")]
public class CharityApiTests {

    private readonly ApplicationFactory<Program> _factory = new ApplicationFactory<Program>();

    [Test, Description("Get all charities")]
    public async Task GetCharities(){
        //Arrange

        HttpClient client = _factory.CreateClient();

        //Act
        var response = await client.GetAsync("/api/charities");
        
        var json = await response.Content.ReadAsStringAsync();


        var obj = JsonConvert.DeserializeObject<Charities>(json);
        
        //Assert
            obj?.all?.ForEach(charity =>
            {
                Assert.That(charity, Has.Property("CharityName"));
                Assert.That(charity, Has.Property("Description"));
                Assert.That(charity, Has.Property("AddressLine1"));
                Assert.That(charity, Has.Property("AddressLine2"));
                Assert.That(charity, Has.Property("AddressLine3"));
                Assert.That(charity, Has.Property("City"));
                Assert.That(charity, Has.Property("PostCode"));



            });

        Assert.That(obj?.all?.Count(), Is.EqualTo(3));

    }

}

