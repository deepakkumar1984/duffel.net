using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class OrderChangeRequests : Resource
{
    /// <summary>
    /// Endpoint path
    /// </summary>
    private readonly string path;

    public OrderChangeRequests(HttpClient client) : base(client)
    {
        path = "air/order_change_requests";
    }

    /// <summary>
    /// Retrieves an order change request by its ID
    /// </summary>
    /// <param name="id">The ID of your order change request</param>
    /// <returns>A response containing the details of the order change request</returns>
    public async Task<DuffelResponse<OrderChangeRequestResponse>> GetAsync(string id)
    {
        var response = await RequestAsync(HttpMethod.Get, $"{path}/{id}");
        return JsonSerializer.Deserialize<DuffelResponse<OrderChangeRequestResponse>>(response);
    }

    /// <summary>
    /// To change flights on an existing paid order, you'll need to create an order change request.
    /// </summary>
    /// <param name="options">The options for creating the order change request</param>
    /// <returns>A response containing the created order change request</returns>
    public async Task<DuffelResponse<OrderChangeRequestResponse>> CreateAsync(CreateOrderChangeRequest options)
    {
        var response = await RequestAsync(HttpMethod.Post, path, options);
        return JsonSerializer.Deserialize<DuffelResponse<OrderChangeRequestResponse>>(response);
    }
}
