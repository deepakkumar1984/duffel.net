using System;

public class Duffel
{
    private readonly Client _client;

    public Aircraft Aircraft { get; }
    public Airlines Airlines { get; }
    public Airports Airports { get; }
    public Offers Offers { get; }
    public OfferRequests OfferRequests { get; }
    public Orders Orders { get; }
    public OrderChangeRequests OrderChangeRequests { get; }
    public OrderChangeOffers OrderChangeOffers { get; }
    public OrderChanges OrderChanges { get; }
    public OrderCancellations OrderCancellations { get; }
    public Payments Payments { get; }
    public SeatMaps SeatMaps { get; }
    public PaymentIntents PaymentIntents { get; }
    public PartialOfferRequests PartialOfferRequests { get; }
    public Suggestions Suggestions { get; }
    public Refunds Refunds { get; }
    public Webhooks Webhooks { get; }
    public Stays Stays { get; }
    public ThreeDSecureSessions ThreeDSecureSessions { get; }
    public Cards Cards { get; }

    public Duffel(Config config)
    {
        _client = new Client(config);

        Aircraft = new Aircraft(_client);
        Airlines = new Airlines(_client);
        Airports = new Airports(_client);
        Offers = new Offers(_client);
        OfferRequests = new OfferRequests(_client);
        Orders = new Orders(_client);
        OrderChangeRequests = new OrderChangeRequests(_client);
        OrderChangeOffers = new OrderChangeOffers(_client);
        OrderChanges = new OrderChanges(_client);
        OrderCancellations = new OrderCancellations(_client);
        Payments = new Payments(_client);
        SeatMaps = new SeatMaps(_client);
        PaymentIntents = new PaymentIntents(_client);
        PartialOfferRequests = new PartialOfferRequests(_client);
        Suggestions = new Suggestions(_client);
        Refunds = new Refunds(_client);
        Webhooks = new Webhooks(_client);
        Stays = new Stays(_client);
        ThreeDSecureSessions = new ThreeDSecureSessions(_client);

        var cardsClient = new Client(new Config
        {
            Token = config.Token,
            BasePath = "https://api.duffel.cards",
            ApiVersion = config.ApiVersion,
            Debug = config.Debug,
            Source = config.Source
        });
        Cards = new Cards(cardsClient);
    }
}
