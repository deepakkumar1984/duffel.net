using System;
using System.Collections.Generic;
using System.Security.AccessControl;

public class OrderChangeOffer
{
    /// <summary>
    /// The price of this offer as a change to your existing order, excluding taxes
    /// </summary>
    public string ChangeTotalAmount { get; set; }

    /// <summary>
    /// The currency of the change total amount, as an ISO 4217 currency code
    /// </summary>
    public string ChangeTotalCurrency { get; set; }

    /// <summary>
    /// The ISO 8601 datetime at which the offer was created
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// The ISO 8601 datetime at which the offer will expire
    /// </summary>
    public DateTime ExpiresAt { get; set; }

    /// <summary>
    /// Duffel's unique identifier for the order change offer
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// The price of this offer if it was newly purchased, excluding taxes
    /// </summary>
    public string NewTotalAmount { get; set; }

    /// <summary>
    /// The currency of the new total amount, as an ISO 4217 currency code
    /// </summary>
    public string NewTotalCurrency { get; set; }

    /// <summary>
    /// The ID for an order change if one has already been created from this order change offer
    /// </summary>
    public string OrderChangeId { get; set; }

    /// <summary>
    /// The penalty price imposed by the airline for making this change
    /// </summary>
    public string PenaltyAmount { get; set; }

    /// <summary>
    /// The currency of the penalty amount, as an ISO 4217 currency code
    /// </summary>
    public string PenaltyCurrency { get; set; }

    /// <summary>
    /// Where the refund, once confirmed, will be sent
    /// </summary>
    public RefundTo RefundTo { get; set; }

    /// <summary>
    /// The slices to be added and/or removed
    /// </summary>
    public OrderChangeOfferSlices Slices { get; set; }

    /// <summary>
    /// The ISO 8601 datetime at which the offer was last updated
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}

public class OrderChangeOfferSlices
{
    /// <summary>
    /// The slices that will be added to the order
    /// </summary>
    public List<OrderChangeOfferSlice> Add { get; set; }

    /// <summary>
    /// The slices that will be removed from the order
    /// </summary>
    public List<OrderChangeOfferSlice> Remove { get; set; }
}

public class OrderChangeOfferSlice
{
    /// <summary>
    /// The city or airport where this slice ends
    /// </summary>
    public Place Destination { get; set; }

    /// <summary>
    /// The type of the destination
    /// </summary>
    public PlaceType DestinationType { get; set; }

    /// <summary>
    /// The duration of the slice, represented as an ISO 8601 duration
    /// </summary>
    public string Duration { get; set; }

    /// <summary>
    /// Duffel's unique identifier for the slice
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// The city or airport where this slice begins
    /// </summary>
    public Place Origin { get; set; }

    /// <summary>
    /// The type of the origin
    /// </summary>
    public PlaceType OriginType { get; set; }

    /// <summary>
    /// The segments for this slice
    /// </summary>
    public List<OfferSliceSegment> Segments { get; set; }
}

public enum RefundTo
{
    ArcBspCash,
    Balance,
    Card,
    Voucher,
    AwaitingPayment,
    OriginalFormOfPayment
}
