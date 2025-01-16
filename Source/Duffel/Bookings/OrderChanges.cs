public class OrderChanges : Resource
{
    public string Path { get; private set; }

    public OrderChanges(Client client) : base(client)
    {
        Path = "air/order_changes";
    }

    /// <summary>
    /// To begin the process of changing an order you need to create an order change.
    /// The OrderChange will contain the `selected_order_change_offer` reference of the change you wish to make to your order.
    /// </summary>
    /// <param name="options">The parameters for creating an order change.</param>
    /// <returns>The created order change offer slice.</returns>
    public async Task<DuffelResponse<OrderChangeOfferSlice>> CreateAsync(CreateOrderChangeParameters options)
    {
        return await RequestAsync<OrderChangeOfferSlice>(HttpMethod.Post, Path, options);
    }

    /// <summary>
    /// Retrieves an order change by its ID.
    /// </summary>
    /// <param name="id">Duffel's unique identifier for the order change.</param>
    /// <returns>The order change offer slice.</returns>
    public async Task<DuffelResponse<OrderChangeOfferSlice>> GetAsync(string id)
    {
        return await RequestAsync<OrderChangeOfferSlice>(HttpMethod.Get, $"{Path}/{id}");
    }

    /// <summary>
    /// Once you've created a pending order change, you'll know the change_total_amount due for the change.
    /// </summary>
    /// <param name="id">Duffel's unique identifier for the order change.</param>
    /// <param name="options">The payment details to use to pay for the order change.</param>
    /// <returns>The confirmed order change offer slice.</returns>
    public async Task<DuffelResponse<OrderChangeOfferSlice>> ConfirmAsync(string id, ConfirmOrderChangePayment options)
    {
        return await RequestAsync<OrderChangeOfferSlice>(HttpMethod.Post, $"{Path}/{id}/actions/confirm", options);
    }
}
