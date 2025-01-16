using System;
using System.Threading.Tasks;

public class Refunds : Resource
{
    private readonly string _path;

    public Refunds(Client client) : base(client)
    {
        _path = "payments/refunds";
    }

    /// <summary>
    /// You should use this API to get the complete, up-to-date information about a Refund.
    /// </summary>
    /// <param name="id">Duffel's unique identifier for the Refund</param>
    /// <returns>Up-to-date information about the Refund</returns>
    public async Task<DuffelResponse<Refund>> GetAsync(string id)
    {
        return await RequestAsync<Refund>("GET", $"{_path}/{id}");
    }

    /// <summary>
    /// Create a Refund to refund some money to a customer that they paid using a Payment Intent.
    /// You must specify the amount and currency. The currency is currently limited to the currency in which the Payment Intent was made.
    /// </summary>
    /// <param name="params">Endpoint parameters (amount, currency, and payment_intent_id)</param>
    /// <returns>The created Refund</returns>
    public async Task<DuffelResponse<Refund>> CreateAsync(CreateRefund @params)
    {
        return await RequestAsync<Refund>("POST", _path, @params);
    }
}
