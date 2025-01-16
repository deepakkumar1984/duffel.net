using System;
using System.Collections.Generic;

public class PaymentIntent
{
    public string Amount { get; set; }
    public string CardCountryCode { get; set; }
    public string CardLastFourDigits { get; set; }
    public CardNetwork? CardNetwork { get; set; }
    public string ClientToken { get; set; }
    public DateTime ConfirmedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Currency { get; set; }
    public string FeesAmount { get; set; }
    public string FeesCurrency { get; set; }
    public string Id { get; set; }
    public bool LiveMode { get; set; }
    public string NetAmount { get; set; }
    public string NetCurrency { get; set; }
    public List<Refund> Refunds { get; set; }
    public PaymentIntentStatus? Status { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public class Refund
{
    public string Amount { get; set; }
    public string Arrival { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Currency { get; set; }
    public string Destination { get; set; }
    public string Id { get; set; }
    public bool LiveMode { get; set; }
    public string NetAmount { get; set; }
    public string NetCurrency { get; set; }
    public string PaymentIntentId { get; set; }
    public RefundStatus Status { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public enum CardNetwork
{
    Amex,
    CartesBancaires,
    Diners,
    Discover,
    Interac,
    Jcb,
    Mastercard,
    Unionpay,
    Visa,
    Unknown
}

public enum PaymentIntentStatus
{
    RequiresPaymentMethod,
    RequiresConfirmation,
    RequiresAction,
    Processing,
    RequiresCapture,
    Cancelled,
    Succeeded
}

public enum RefundStatus
{
    Succeeded,
    Pending,
    Failed
}

public class CreatePaymentIntent
{
    public string Amount { get; set; }
    public string Currency { get; set; }
}
