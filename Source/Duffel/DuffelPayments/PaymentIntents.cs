using System;
using System.Threading.Tasks;

public class PaymentIntents : Resource
{
    private readonly string _path;

    public PaymentIntents(Client client) : base(client)
    {
        _path = "payments/payment_intents";
    }

    /// <summary>
    /// You should use this API to get the complete, up-to-date information about a Payment Intent.
    /// </summary>
    /// <param name="id">Duffel's unique identifier for the Payment Intent</param>
    /// <returns>Up-to-date information about the Payment Intent</returns>
    public async Task<DuffelResponse<PaymentIntent>> GetAsync(string id)
    {
        return await RequestAsync<PaymentIntent>("GET", $"{_path}/{id}");
    }

    /// <summary>
    /// Once you've successfully collected the customer's card details, using the `client_token` from when you first created the Payment Intent,
    /// you then need to confirm it using this endpoint.
    /// Once confirmed, the amount charged to your customer's card will be added to your `Balance` (minus any Duffel Payment fees).
    /// </summary>
    /// <param name="id">Duffel's unique identifier for the Payment Intent</param>
    /// <returns>The confirmed Payment Intent</returns>
    public async Task<DuffelResponse<PaymentIntent>> ConfirmAsync(string id)
    {
        return await RequestAsync<PaymentIntent>("POST", $"{_path}/{id}/actions/confirm");
    }

    /// <summary>
    /// To begin the process of collecting a card payment from your customer, you need to create a Payment Intent.
    /// The Payment Intent will contain a `client_token` that you use to collect the card payment in your application.
    /// If the Payment Intent is created in test mode you should use a test card.
    /// </summary>
    /// <param name="params">Endpoint parameters (amount and currency)</param>
    /// <returns>The created Payment Intent</returns>
    public async Task<DuffelResponse<PaymentIntent>> CreateAsync(CreatePaymentIntent @params)
    {
        return await RequestAsync<PaymentIntent>("POST", _path, @params);
    }
}
