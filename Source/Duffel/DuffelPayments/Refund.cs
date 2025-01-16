using System;

public class Refund
{
    /// <summary>
    /// The amount of the Payment Intent that will be refunded to the customer.
    /// </summary>
    public string Amount { get; set; }

    /// <summary>
    /// When the refund is expected to arrive in the destination.
    /// </summary>
    public string Arrival { get; set; }

    /// <summary>
    /// The ISO 8601 datetime at which the Refund was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// The currency of the amount, as an ISO 4217 currency code.
    /// It will always match the currency of the Payment Intent.
    /// </summary>
    public string Currency { get; set; }

    /// <summary>
    /// Where the Refund amount will be sent to.
    /// </summary>
    public string Destination { get; set; } = "original_form_of_payment";

    /// <summary>
    /// Duffel's unique identifier for the Refund.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Whether the Refund was created in live mode.
    /// </summary>
    public bool LiveMode { get; set; }

    /// <summary>
    /// The amount deducted from your Balance to cover the Refund amount.
    /// </summary>
    public string NetAmount { get; set; }

    /// <summary>
    /// The currency of the net_amount, as an ISO 4217 currency code.
    /// This currency will match your Balance currency.
    /// </summary>
    public string NetCurrency { get; set; }

    /// <summary>
    /// Duffel's unique identifier for the Payment Intent that the Refund is for.
    /// </summary>
    public string PaymentIntentId { get; set; }

    /// <summary>
    /// The status of the Refund.
    /// </summary>
    public RefundStatus Status { get; set; }

    /// <summary>
    /// The ISO 8601 datetime at which the Refund was updated.
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}

public class CreateRefund
{
    /// <summary>
    /// This amount that will be refunded to the customer's card.
    /// </summary>
    public string Amount { get; set; }

    /// <summary>
    /// The currency of the amount, as an ISO 4217 currency code.
    /// It must match the Payment Intent currency.
    /// </summary>
    public string Currency { get; set; }

    /// <summary>
    /// Duffel's unique identifier for the Payment Intent that the Refund is for.
    /// </summary>
    public string PaymentIntentId { get; set; }
}

public enum RefundStatus
{
    Succeeded,
    Pending,
    Failed
}
