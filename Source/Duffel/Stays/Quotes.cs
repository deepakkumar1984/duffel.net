using System.Threading.Tasks;

public class Quotes : Resource
{
    private readonly string _path;

    public Quotes(Client client) : base(client)
    {
        _path = "stays/quotes";
    }

    /// <summary>
    /// Create a quote for the selected rate.
    /// </summary>
    /// <param name="rateId">The ID of the rate to create a quote for.</param>
    /// <returns>A DuffelResponse containing the created quote.</returns>
    public async Task<DuffelResponse<StaysQuote>> CreateAsync(string rateId)
    {
        var data = new { rate_id = rateId };
        return await RequestAsync<StaysQuote>("POST", _path, data);
    }
}

public class StaysQuote
{
    public string Id { get; set; }
    public string RateId { get; set; }
    // Add other properties as needed
}