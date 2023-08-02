using System.Text.Json;

namespace dotnet_charity_db.Models;

public class Charity {

    public string CharityName;
    public string Description;
    public string AddressLine1;

    public string AddressLine2;
    public string AddressLine3;

    public string City;

    public string PostCode;

    public Charity(Int32 charityId, string Charityname, string Description, string AddressLine1, string AddressLine2, string AddressLine3, string City, string PostCode){
        this.CharityName = Charityname;
        this.Description = Description;
        this.AddressLine1 = AddressLine1;
        this.AddressLine2 = AddressLine2;
        this.AddressLine3 = AddressLine3;
        this.City = City;
        this.PostCode = PostCode;

    }

    public override string ToString() => JsonSerializer.Serialize<Charity>(this);
    
}