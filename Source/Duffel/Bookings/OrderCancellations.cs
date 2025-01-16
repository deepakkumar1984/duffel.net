using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class OrderCancellations : Resource
{
    /// <summary>
    /// Endpoint path
    /// </summary>
    private readonly string _path;

    public OrderCancellations(Client client) : base(client)
    {
        _path = "air/order_cancellations";
    }

    /// <summary>
    /// Retrieves an order cancellation by its ID
    /// </summary>
    /// <param name="id">Duffel's unique identifier for the order cancellation</param>
    /// <returns>Order cancellation details</returns>
    public async Task<DuffelResponse<OrderCancellation>> GetAsync(string id)
    {
        return await RequestAsync<DuffelResponse<OrderCancellation>>(new RequestOptions
        {
            Method = "GET",
            Path = $"{_path}/{id}"
        });
    }

    /// <summary>
    /// Retrieves a page of order cancellations
    /// </summary>
    /// <param name="params">Pagination and filter options</param>
    /// <returns>A list of order cancellations</returns>
    public async Task<DuffelResponse<List<OrderCancellation>>> ListAsync(ListOrderCancellationsParams parameters = null)
    {
        return await RequestAsync<DuffelResponse<List<OrderCancellation>>>(new RequestOptions
        {
            Method = "GET",
            Path = _path,
            Params = parameters
        });
    }

    /// <summary>
    /// Retrieves a generator of all order cancellations
    /// </summary>
    /// <param name="params">Pagination and filter options</param>
    /// <returns>A generator of order cancellations</returns>
    public async IAsyncEnumerable<OrderCancellation> ListWithGeneratorAsync(ListOrderCancellationsParams parameters = null)
    {
        await foreach (var cancellation in PaginatedRequestAsync<OrderCancellation>(new PaginatedRequestOptions
        {
            Path = _path,
            Params = parameters
        }))
        {
            yield return cancellation;
        }
    }

    /// <summary>
    /// Create order cancellation
    /// </summary>
    /// <param name="options">The options for creating the order cancellation</param>
    /// <returns>Created order cancellation details</returns>
    public async Task<DuffelResponse<OrderCancellation>> CreateAsync(CreateOrderCancellation options)
    {
        return await RequestAsync<DuffelResponse<OrderCancellation>>(new RequestOptions
        {
            Method = "POST",
            Path = _path,
            Data = options
        });
    }

    /// <summary>
    /// Confirm order cancellation
    /// </summary>
    /// <param name="id">Duffel's unique identifier for the order to cancel</param>
    /// <returns>Confirmed order cancellation details</returns>
    public async Task<DuffelResponse<OrderCancellation>> ConfirmAsync(string id)
    {
        return await RequestAsync<DuffelResponse<OrderCancellation>>(new RequestOptions
        {
            Method = "POST",
            Path = $"{_path}/{id}/actions/confirm"
        });
    }
}
