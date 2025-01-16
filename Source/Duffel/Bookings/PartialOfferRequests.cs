public class PartialOfferRequests : Resource
{
    /// <summary>
    /// Endpoint path
    /// </summary>
    private readonly string _path;

    public PartialOfferRequests(Client client) : base(client)
    {
        _path = "air/partial_offer_requests";
    }

    /// <summary>
    /// Retrieves a partial offers request by its ID, only including partial offers for the current slice of multi-step search flow.
    /// </summary>
    /// <param name="id">Duffel's unique identifier for the partial offer request</param>
    /// <param name="options">Selected partial offers</param>
    public async Task<DuffelResponse<OfferRequest>> GetAsync(
        string id,
        SelectedPartialOffersParams options = null)
    {
        return await RequestAsync<DuffelResponse<OfferRequest>>(new Request
        {
            Method = HttpMethod.Get,
            Path = $"{_path}/{id}",
            QueryParams = options
        });
    }

    /// <summary>
    /// To search for and select flights separately for each slice of the journey, you'll need to create a partial offer request.
    /// </summary>
    /// <typeparam name="TQueryParams">The type of query parameters</typeparam>
    /// <param name="options">The parameters for making a partial offer request</param>
    public async Task<DuffelResponse<OfferRequest>> CreateAsync<TQueryParams>(
        CreateOfferRequest options) where TQueryParams : CreatePartialOfferRequestQueryParam
    {
        var data = new Dictionary<string, object>(options.ToDictionary());
        var supplierTimeout = options.SupplierTimeout;

        return await RequestAsync<DuffelResponse<OfferRequest>>(new Request
        {
            Method = HttpMethod.Post,
            Path = $"{_path}/",
            Body = data,
            QueryParams = supplierTimeout != null ? new { supplier_timeout = supplierTimeout } : null
        });
    }

    /// <summary>
    /// Retrieves an offer request with offers for fares matching selected partial offers.
    /// </summary>
    /// <param name="id">Duffel's unique identifier for the partial offer request</param>
    /// <param name="options">Selected partial offers</param>
    public async Task<DuffelResponse<OfferRequest>> GetFaresByIdAsync(
        string id,
        SelectedPartialOffersParams options = null)
    {
        return await RequestAsync<DuffelResponse<OfferRequest>>(new Request
        {
            Method = HttpMethod.Get,
            Path = $"{_path}/{id}/fares",
            QueryParams = options
        });
    }
}
