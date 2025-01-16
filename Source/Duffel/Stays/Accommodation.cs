using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Accommodation : Resource
{
    private readonly string _path;

    public Accommodation(Client client) : base(client)
    {
        _path = "stays/accommodation";
    }

    /// <summary>
    /// Get suggestions for accommodation given a query string.
    /// </summary>
    /// <param name="query">The query string for the search.</param>
    /// <param name="location">Optional location parameters for the search.</param>
    /// <returns>A DuffelResponse containing a list of accommodation suggestions.</returns>
    public async Task<DuffelResponse<List<StaysAccommodationSuggestion>>> SuggestionsAsync(string query, LocationParams location = null)
    {
        var data = new
        {
            query = query,
            location = location
        };
        return await RequestAsync<List<StaysAccommodationSuggestion>>("POST", $"{_path}/suggestions", data);
    }

    /// <summary>
    /// Get information about an accommodation with a specific Duffel ID.
    /// </summary>
    /// <param name="id">The Duffel ID of the Accommodation.</param>
    /// <returns>A DuffelResponse containing the accommodation details.</returns>
    public async Task<DuffelResponse<StaysAccommodation>> GetAsync(string id)
    {
        return await RequestAsync<StaysAccommodation>("GET", $"{_path}/{id}");
    }

    /// <summary>
    /// Retrieves a page of accommodation.
    /// </summary>
    /// <param name="params">The parameters for listing accommodations (radius, latitude, longitude, etc.).</param>
    /// <returns>A DuffelResponse containing a list of accommodations.</returns>
    public async Task<DuffelResponse<List<StaysAccommodation>>> ListAsync(ListAccommodationParams @params)
    {
        return await RequestAsync<List<StaysAccommodation>>("GET", _path, @params);
    }

    /// <summary>
    /// Retrieves a generator of accommodation pages given the criteria in the params.
    /// </summary>
    /// <param name="params">The parameters for listing accommodations (radius, latitude, longitude, etc.).</param>
    /// <returns>An asynchronous generator of accommodation pages.</returns>
    public async IAsyncEnumerable<DuffelResponse<List<StaysAccommodation>>> ListWithGeneratorAsync(ListAccommodationParams @params)
    {
        await foreach (var response in PaginatedRequestAsync<List<StaysAccommodation>>(_path, @params))
        {
            yield return response;
        }
    }
}

public class LocationParams
{
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public int? Radius { get; set; }
}

public class ListAccommodationParams
{
    public int? Radius { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string Before { get; set; }
    public string After { get; set; }
    public int? Limit { get; set; }
}

public class StaysAccommodationSuggestion
{
    public string Id { get; set; }
    public string Name { get; set; }
    // Add other properties as needed
}

public class StaysAccommodation
{
    public string Id { get; set; }
    public string Name { get; set; }
    // Add other properties as needed
}
