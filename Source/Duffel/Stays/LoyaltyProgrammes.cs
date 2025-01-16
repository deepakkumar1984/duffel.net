using System.Collections.Generic;
using System.Threading.Tasks;

public class LoyaltyProgrammes : Resource
{
    private readonly string _path;

    public LoyaltyProgrammes(Client client) : base(client)
    {
        _path = "stays/loyalty_programmes";
    }

    /// <summary>
    /// List all the loyalty programmes supported by Duffel Stays.
    /// </summary>
    /// <returns>A DuffelResponse containing a list of loyalty programmes.</returns>
    public async Task<DuffelResponse<List<StaysLoyaltyProgramme>>> ListAsync()
    {
        return await RequestAsync<List<StaysLoyaltyProgramme>>("GET", _path);
    }
}

public class StaysLoyaltyProgramme
{
    public string Id { get; set; }
    public string Name { get; set; }
    // Add other properties as needed
}
