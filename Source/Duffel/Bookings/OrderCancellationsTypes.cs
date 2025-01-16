using System;
using System.Collections.Generic;

public class CreateOrderCancellation
{
    /// <summary>
    /// Duffel's unique identifier for the order
    /// </summary>
    public string OrderId { get; set; }
}

public class ListOrderCancellationsParams : PaginationMeta
{
    /// <summary>
    /// Duffel's unique identifier for the order, returned when it was created
    /// </summary>
    public string OrderId { get; set; }
}

public class OrderCancellationAirlineCredit
{
    /// <summary>
    /// Duffel's unique identifier for the airline credit
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// The human-readable name used by the airline to categorize the type of credit being offered
    /// </summary>
    public string CreditName { get; set; }

    /// <summary>
    /// The code which identifies the airline credit to the airline and will be used to redeem the airline credit
    /// </summary>
    public string CreditCode { get; set; }

    /// <summary>
    /// The monetary value associated with this airline credit
    /// </summary>
    public string CreditAmount { get; set; }

    /// <summary>
    /// The currency in which this airline credit is issued, as an ISO 4217 currency code
    /// </summary>
    public string CreditCurrency { get; set; }

    /// <summary>
    /// The date the credit was issued
    /// </summary>
    public DateTime IssuedOn { get; set; }

    /// <summary>
    /// Duffel's unique identifier for the passenger on the order that the credit is associated with
    /// </summary>
    public string PassengerId { get; set; }
}

public class OrderCancellation
{
    /// <summary>
    /// The ISO 8601 datetime that indicates when the order cancellation was confirmed
    /// </summary>
    public DateTime? ConfirmedAt { get; set; }

    /// <summary>
    /// The ISO 8601 datetime at which the order cancellation was created
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// The ISO 8601 datetime by which this cancellation must be confirmed
    /// </summary>
    public DateTime ExpiresAt { get; set; }

    /// <summary>
    /// Duffel's unique identifier for the order cancellation
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Whether the order cancellation was created in live mode
    /// </summary>
    public bool LiveMode { get; set; }

    /// <summary>
    /// Duffel's unique identifier for the order
    /// </summary>
    public string OrderId { get; set; }

    /// <summary>
    /// The amount that will be returned to the original payment method if the order is cancelled
    /// </summary>
    public string RefundAmount { get; set; }

    /// <summary>
    /// The currency of the refund amount, as an ISO 4217 currency code
    /// </summary>
    public string RefundCurrency { get; set; }

    /// <summary>
    /// Where the refund, once confirmed, will be sent
    /// </summary>
    public RefundTo RefundTo { get; set; }

    /// <summary>
    /// The airline credits for this OrderCancellation
    /// </summary>
    public List<OrderCancellationAirlineCredit> AirlineCredits { get; set; }
}

public enum RefundTo
{
    ArcBspCash,
    Balance,
    Card,
    Voucher,
    AwaitingPayment,
    AirlineCredits
}
