using System.Collections.Generic;
using System.Threading.Tasks;

public class OfferRequests : Resource
{
    /// <summary>
    /// Endpoint path
    /// </summary>
    private readonly string path;

    public OfferRequests(Client client) : base(client)
    {
        path = "air/offer_requests";
    }

    /// <summary>
    /// Retrieves an offer request by its ID
    /// </summary>
    /// <param name="id">Duffel's unique identifier for the offer request</param>
    /// <returns>Offer request details</returns>
    public async Task<DuffelResponse<OfferRequest>> GetAsync(string id)
    {
        return await RequestAsync<DuffelResponse<OfferRequest>>(new RequestOptions
        {
            Method = HttpMethod.Get,
            Path = $"{path}/{id}"
        });
    }

    /// <summary>
    /// Retrieves a page of offer requests. The results may be returned in any order.
    /// </summary>
    /// <param name="options">Pagination options (optional: limit, after, before)</param>
    /// <returns>List of offer requests</returns>
    public async Task<DuffelResponse<List<OfferRequest>>> ListAsync(PaginationMeta options = null)
    {
        return await RequestAsync<DuffelResponse<List<OfferRequest>>>(new RequestOptions
        {
            Method = HttpMethod.Get,
            Path = path,
            QueryParams = options
        });
    }

    /// <summary>
    /// Retrieves a generator of all offer requests. The results may be returned in any order.
    /// </summary>
    /// <returns>Generator for offer requests</returns>
    public async IAsyncEnumerable<DuffelResponse<OfferRequest>> ListWithGeneratorAsync()
    {
        await foreach (var response in PaginatedRequestAsync<DuffelResponse<OfferRequest>>(path))
        {
            yield return response;
        }
    }

    /// <summary>
    /// To search for flights, you'll need to create an `offer request`.
    /// </summary>
    /// <typeparam name="QueryParams">Query parameters including return_offers or supplier_timeout</typeparam>
    /// <param name="options">Parameters for making an offer request</param>
    /// <returns>Offer request response</returns>
    public async Task<DuffelResponse<OfferRequest>> CreateAsync(QueryParams options)
    {
        var queryParams = new Dictionary<string, object>();

        if (options.ReturnOffers.HasValue)
        {
            queryParams["return_offers"] = options.ReturnOffers.Value;
        }

        if (options.SupplierTimeout.HasValue)
        {
            queryParams["supplier_timeout"] = options.SupplierTimeout.Value;
        }

        return await RequestAsync<DuffelResponse<OfferRequest>>(new RequestOptions
        {
            Method = HttpMethod.Post,
            Path = $"{path}/",
            Body = options,
            QueryParams = queryParams
        });
    }
}

public class QueryParams
{
    public bool? ReturnOffers { get; set; }
    public int? SupplierTimeout { get; set; }
}
