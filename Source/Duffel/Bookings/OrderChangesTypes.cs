public class OrderChange
{
    public string ChangeTotalAmount { get; set; }
    public string ChangeTotalCurrency { get; set; }
    public bool LiveMode { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ConfirmedAt { get; set; }
    public DateTime ExpiresAt { get; set; }
    public string Id { get; set; }
    public string NewTotalAmount { get; set; }
    public string NewTotalCurrency { get; set; }
    public string OrderId { get; set; }
    public string PenaltyTotalAmount { get; set; }
    public string PenaltyTotalCurrency { get; set; }
    public string RefundTo { get; set; } // "voucher" or "original_form_of_payment"
    public OrderChangeOfferSlices Slices { get; set; }
    public List<PaymentType> AvailablePaymentTypes { get; set; }
}

public class CreateOrderChangeParameters
{
    public string SelectedOrderChangeOffer { get; set; }
}

public class ConfirmOrderChangePayment
{
    public string Amount { get; set; }
    public string Currency { get; set; }
    public PaymentType Type { get; set; }
}
