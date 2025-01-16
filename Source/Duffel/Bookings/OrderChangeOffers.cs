using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class OrderChangeOffers : Resource
{
    /// <summary>
    /// Endpoint path
    /// </summary>
    private readonly string path;

    public OrderChangeOffers(Client client) : base(client)
    {
        path = "air/order_change_offers";
    }

    /// <summary>
    /// Retrieves an order change offer by its ID
    /// </summary>
    /// <param name="id">The ID of your order change offer</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the order change offer details.</returns>
    public async Task<DuffelResponse<OrderChangeOffer>> GetAsync(string id)
    {
        var url = $"{path}/{id}";
        return await RequestAsync<DuffelResponse<OrderChangeOffer>>(HttpMethod.Get, url);
    }

    /// <summary>
    /// Retrieves a page of order change offers. The results may be returned in any order.
    /// </summary>
    /// <param name="options">Pagination options (optional: limit, after, before)</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of order change offers.</returns>
    public async Task<DuffelResponse<List<OrderChangeOffer>>> ListAsync(PaginationMeta options = null)
    {
        var url = path;
        return await RequestAsync<DuffelResponse<List<OrderChangeOffer>>>(HttpMethod.Get, url, options);
    }

    /// <summary>
    /// Retrieves a generator of all order change offers. The results may be returned in any order.
    /// </summary>
    /// <returns>An asynchronous generator for order change offers.</returns>
    public async IAsyncEnumerable<DuffelResponse<OrderChangeOffer>> ListWithGeneratorAsync()
    {
        await foreach (var response in PaginatedRequestAsync<DuffelResponse<OrderChangeOffer>>(path))
        {
            yield return response;
        }
    }
}
