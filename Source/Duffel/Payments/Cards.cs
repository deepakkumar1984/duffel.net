using System;
using System.Threading.Tasks;

public class Cards : Resource
{
    private readonly string _path;

    public Cards(Client client) : base(client)
    {
        _path = "payments/cards";
    }

    /// <summary>
    /// Create a Duffel card record.
    /// </summary>
    /// <param name="data">The card parameters for creating a Duffel card record.</param>
    /// <returns>A DuffelResponse containing the card record details.</returns>
    public async Task<DuffelResponse<CardRecord>> CreateAsync(CardParameters data)
    {
        return await RequestAsync<CardRecord>("POST", _path, data);
    }
}

public class CardParameters
{
    /// <summary>
    /// The first line of the card owner's address.
    /// </summary>
    public string AddressLine1 { get; set; }

    /// <summary>
    /// The card owner's postal code (or zip code).
    /// </summary>
    public string AddressPostalCode { get; set; }

    /// <summary>
    /// The card owner's city.
    /// </summary>
    public string AddressCity { get; set; }

    /// <summary>
    /// The card owner's region or state.
    /// </summary>
    public string AddressRegion { get; set; }

    /// <summary>
    /// The ISO 3166-1 alpha-2 code for the card owner's country.
    /// </summary>
    public string AddressCountryCode { get; set; }

    /// <summary>
    /// The brand or the type of the card.
    /// </summary>
    public CardBrand Brand { get; set; }

    /// <summary>
    /// The month that the card expires in as a two-digit string, e.g. "01".
    /// </summary>
    public string ExpiryMonth { get; set; }

    /// <summary>
    /// The year that the card expires in as a two-digit string, e.g. "28".
    /// </summary>
    public string ExpiryYear { get; set; }

    /// <summary>
    /// The card owner's name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The card number.
    /// </summary>
    public string Number { get; set; }

    /// <summary>
    /// The card verification code.
    /// </summary>
    public string Cvc { get; set; }

    /// <summary>
    /// Set to true to indicate that this card can be used multiple times.
    /// </summary>
    public bool MultiUse { get; set; }
}

public class CardRecord
{
    public string Id { get; set; }
    public bool LiveMode { get; set; }
    public bool MultiUse { get; set; }
    public DateTime? UnavailableAt { get; set; }
    public string Brand { get; set; }
    public string Last4Digits { get; set; }
}

public enum CardBrand
{
    Visa,
    Mastercard,
    Uatp,
    AmericanExpress,
    DinersClub,
    Jcb
}
