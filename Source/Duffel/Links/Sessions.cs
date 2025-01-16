using System;
using System.Threading.Tasks;

public class Sessions : Resource
{
    private readonly string _path;

    public Sessions(Client client) : base(client)
    {
        _path = "links/sessions";
    }

    /// <summary>
    /// Create a Duffel Links Session per the configuration.
    /// </summary>
    /// <param name="data">The session parameters for creating a Duffel Links session.</param>
    /// <returns>A DuffelResponse containing the session details.</returns>
    public async Task<DuffelResponse<Session>> CreateAsync(SessionParameters data)
    {
        return await RequestAsync<Session>("POST", _path, data);
    }
}

public class SessionParameters
{
    /// <summary>
    /// A tracking reference for the booking that may be created within this Duffel Links session.
    /// </summary>
    public string Reference { get; set; }

    /// <summary>
    /// A URL to return to when a flight is booked via Duffel Links.
    /// </summary>
    public string SuccessUrl { get; set; }

    /// <summary>
    /// A URL to return to when there is an error within Duffel Links.
    /// </summary>
    public string FailureUrl { get; set; }

    /// <summary>
    /// A URL to return to when the user exits Duffel Links before booking.
    /// </summary>
    public string AbandonmentUrl { get; set; }

    /// <summary>
    /// A primary color to show within Duffel Links.
    /// </summary>
    public string PrimaryColor { get; set; }

    /// <summary>
    /// A URL of the logo to show within Duffel Links.
    /// </summary>
    public string LogoUrl { get; set; }

    /// <summary>
    /// A markup amount to be added to the flights shown within Duffel Links.
    /// </summary>
    public decimal? MarkupAmount { get; set; }

    /// <summary>
    /// A markup currency to be added to the flights shown within Duffel Links.
    /// </summary>
    public string MarkupCurrency { get; set; }

    /// <summary>
    /// A markup percentage to be added to the flights shown within Duffel Links.
    /// </summary>
    public decimal? MarkupRate { get; set; }

    /// <summary>
    /// A text to be shown on the checkout page within Duffel Links.
    /// </summary>
    public string CheckoutDisplayText { get; set; }
}

public class Session
{
    /// <summary>
    /// The Duffel Links URL that contains the specified configuration.
    /// </summary>
    public string Url { get; set; }
}
