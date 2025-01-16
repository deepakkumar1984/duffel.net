using System.Threading.Tasks;

public class SearchResults : Resource
{
    private readonly string _path;

    public SearchResults(Client client) : base(client)
    {
        _path = "stays/search_results";
    }

    /// <summary>
    /// Fetch all rates for the given search result.
    /// </summary>
    /// <param name="searchResultId">The ID of the search result to fetch rates for.</param>
    /// <returns>A DuffelResponse containing the search result with all rates.</returns>
    public async Task<DuffelResponse<StaysSearchResult>> FetchAllRatesAsync(string searchResultId)
    {
        return await RequestAsync<StaysSearchResult>("POST", $"{_path}/{searchResultId}/actions/fetch_all_rates");
    }
}