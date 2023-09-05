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
        )
    {

    }

    public override string ToString() => JsonSerializer.Serialize<Charity>(this);
    
}