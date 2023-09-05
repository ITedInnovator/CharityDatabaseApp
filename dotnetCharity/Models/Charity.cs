using System.Text.Json;

namespace dotnet_charity_db.Models;

public class Charity {

    public string CharityName { get; set; }
    public string Description { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }

    public string AddressLine3 { get; set; }

    public string City { get; set; }

    public string PostCode { get; set; }

    public Charity(
        string name, 
        string description, 
        string address1, 
        string address2, 
        string address3,
        string city,
        string postcode
        )
    {
        CharityName = name;
        Description = description;
        AddressLine1 = address1;
        AddressLine2 = address2;
        AddressLine3 = address3;
        City = city;
        PostCode = postcode;
    }

    public override string ToString() => JsonSerializer.Serialize<Charity>(this);
    
}