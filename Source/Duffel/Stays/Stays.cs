using System.Threading.Tasks;

public class Stays : Resource
{
    private readonly string _path;

    public Accommodation Accommodation { get; }
    public LoyaltyProgrammes LoyaltyProgrammes { get; }
    public Brands Brands { get; }
    public SearchResults SearchResults { get; }
    public Quotes Quotes { get; }
    public Bookings Bookings { get; }

    public Stays(Client client) : base(client)
    {
        _path = "stays";

        Accommodation = new Accommodation(client);
        Brands = new Brands(client);
        LoyaltyProgrammes = new LoyaltyProgrammes(client);
        SearchResults = new SearchResults(client);
        Quotes = new Quotes(client);
        Bookings = new Bookings(client);
    }

    /// <summary>
    /// Search for accommodations.
    /// </summary>
    /// <param name="params">The search parameters.</param>
    /// <returns>A DuffelResponse containing the search result.</returns>
    public async Task<DuffelResponse<StaysSearchResult>> SearchAsync(StaysSearchParams @params)
    {
        return await RequestAsync<StaysSearchResult>("POST", $"{_path}/search", @params);
    }
}

