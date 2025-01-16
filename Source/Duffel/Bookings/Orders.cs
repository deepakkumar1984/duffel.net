public class Orders : Resource
{
    public string Path { get; }

    public Orders(Client client) : base(client)
    {
        Path = "air/orders";
    }

    public async Task<DuffelResponse<Order>> Get(string id)
    {
        return await Request<DuffelResponse<Order>>(new RequestOptions
        {
            Method = HttpMethod.Get,
            Path = $"{Path}/{id}"
        });
    }

    public async Task<DuffelResponse<List<Order>>> List(PaginationMeta pagination, ListParamsOrders options = null)
    {
        return await Request<DuffelResponse<List<Order>>>(new RequestOptions
        {
            Method = HttpMethod.Get,
            Path = Path,
            Params = new { pagination, options }
        });
    }

    public async IAsyncEnumerable<DuffelResponse<Order>> ListWithGenerator(ListParamsOrders options = null)
    {
        await foreach (var response in PaginatedRequest<DuffelResponse<Order>>(new RequestOptions
        {
            Path = Path,
            Params = options
        }))
        {
            yield return response;
        }
    }

    public async Task<DuffelResponse<Order>> Create(CreateOrder options)
    {
        return await Request<DuffelResponse<Order>>(new RequestOptions
        {
            Method = HttpMethod.Post,
            Path = Path,
            Data = options
        });
    }

    public async Task<DuffelResponse<Order>> Update(string id, UpdateSingleOrder options)
    {
        return await Request<DuffelResponse<Order>>(new RequestOptions
        {
            Method = HttpMethod.Patch,
            Path = $"{Path}/{id}",
            Data = options
        });
    }

    public async Task<DuffelResponse<List<OrderAvailableService>>> GetAvailableServices(string id)
    {
        return await Request<DuffelResponse<List<OrderAvailableService>>>(new RequestOptions
        {
            Method = HttpMethod.Get,
            Path = $"{Path}/{id}/available_services"
        });
    }

    public async Task<DuffelResponse<Order>> AddServices(string id, AddServices options)
    {
        return await Request<DuffelResponse<Order>>(new RequestOptions
        {
            Method = HttpMethod.Post,
            Path = $"{Path}/{id}/services",
            Data = options
        });
    }
}
