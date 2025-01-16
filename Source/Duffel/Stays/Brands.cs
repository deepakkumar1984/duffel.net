using System.Collections.Generic;
using System.Threading.Tasks;

public class Brands : Resource
{
    private readonly string _path;

    public Brands(Client client) : base(client)
    {
        _path = "stays/brands";
    }

    /// <summary>
    /// Get a brand by ID.
    /// </summary>
    /// <param name="brandId">The ID of the brand.</param>
    /// <returns>A DuffelResponse containing the brand details.</returns>
    public async Task<DuffelResponse<StaysAccommodationBrand>> GetAsync(string brandId)
    {
        return await RequestAsync<StaysAccommodationBrand>("GET", $"{_path}/{brandId}");
    }

    /// <summary>
    /// List all brands.
    /// </summary>
    /// <returns>A DuffelResponse containing a list of brands.</returns>
    public async Task<DuffelResponse<List<StaysAccommodationBrand>>> ListAsync()
    {
        return await RequestAsync<List<StaysAccommodationBrand>>("GET", _path);
    }
}

public class StaysAccommodationBrand
{
    public string Id { get; set; }
    public string Name { get; set; }
    // Add other properties as needed
}
