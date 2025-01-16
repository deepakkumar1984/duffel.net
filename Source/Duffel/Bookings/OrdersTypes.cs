public class Order
{
    public string TaxAmount { get; set; }
    public string TaxCurrency { get; set; }
    public string TotalAmount { get; set; }
    public string TotalCurrency { get; set; }
    public List<OrderSlice> Slices { get; set; }
    public List<OrderService> Services { get; set; }
    public List<OrderPassenger> Passengers { get; set; }
    public OrderPaymentStatus PaymentStatus { get; set; }
    public Airline Owner { get; set; }
    public bool LiveMode { get; set; }
    public string Id { get; set; }
    public List<OrderDocument> Documents { get; set; }
    public string CreatedAt { get; set; }
    public string CancelledAt { get; set; }
    public string BookingReference { get; set; }
    public string BaseCurrency { get; set; }
    public string BaseAmount { get; set; }
    public FlightsConditions Conditions { get; set; }
    public Dictionary<string, string> Metadata { get; set; }
    public List<AirlineInitiatedChange> AirlineInitiatedChanges { get; set; }
    public List<string> AvailableActions { get; set; }
    public string SyncedAt { get; set; }
}

public class CreateOrder
{
    public List<string> SelectedOffers { get; set; }
    public List<CreateOrderService> Services { get; set; }
    public List<CreateOrderPassenger> Passengers { get; set; }
    public List<OrderPayment> Payments { get; set; }
    public string Type { get; set; } // "instant" | "pay_later"
    public Dictionary<string, string> Metadata { get; set; }
}

public class ListParamsOrders
{
    public bool? AwaitingPayment { get; set; }
    public List<string> PassengerNames { get; set; }
    public string BookingReference { get; set; }
}

public class UpdateSingleOrder
{
    public Dictionary<string, string> Metadata { get; set; }
}

public class AddServices
{
    public OrderPayment Payment { get; set; }
    public List<CreateOrderService> AddServices { get; set; }
}

public class CreateOrderService
{
    public string Id { get; set; }
    public int Quantity { get; set; }
}
