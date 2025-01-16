using System;
using System.Collections.Generic;
using System.Security.AccessControl;

public class OrderChangeSliceResponse
{
    public RemoveSlice Remove { get; set; }
    public AddSlice Add { get; set; }

    public class RemoveSlice
    {
        public string SliceId { get; set; }
    }

    public class AddSlice
    {
        public string DepartureDate { get; set; }
        public Place Destination { get; set; }
        public Place Origin { get; set; }
        public CabinClass CabinClass { get; set; }
    }
}

public class OrderChangeOffers
{
    public string UpdatedAt { get; set; }
    public string ChangeTotalAmount { get; set; }
    public string ChangeTotalCurrency { get; set; }
    public string CreatedAt { get; set; }
    public string ExpiresAt { get; set; }
    public string Id { get; set; }
    public string NewTotalAmount { get; set; }
    public string NewTotalCurrency { get; set; }
    public string OrderChangeId { get; set; }
    public string PenaltyAmount { get; set; }
    public string PenaltyCurrency { get; set; }
    public string RefundTo { get; set; }
    public OrderChangeOfferSlices Slices { get; set; }
}

public class OrderChangeRequestResponse
{
    public string Id { get; set; }
    public bool LiveMode { get; set; }
    public List<OrderChangeOffers> OrderChangeOffers { get; set; }
    public string OrderId { get; set; }
    public OrderChangeSliceResponse Slices { get; set; }
}

public class CreateOrderChangeRequest
{
    public OrderChangeSlices Slices { get; set; }
    public string OrderId { get; set; }

    public class OrderChangeSlices
    {
        public List<AddSlice> Add { get; set; }
        public List<RemoveSlice> Remove { get; set; }

        public class AddSlice
        {
            public CabinClass CabinClass { get; set; }
            public string DepartureDate { get; set; }
            public string Destination { get; set; }
            public string Origin { get; set; }
        }

        public class RemoveSlice
        {
            public string SliceId { get; set; }
        }
    }
}

public class OrderChangeOfferSlices
{
    public List<OrderChangeOfferSlice> Add { get; set; }
    public List<OrderChangeOfferSlice> Remove { get; set; }
}

public class OrderChangeOfferSlice
{
    public Place Destination { get; set; }
    public PlaceType DestinationType { get; set; }
    public string Duration { get; set; }
    public string Id { get; set; }
    public Place Origin { get; set; }
    public PlaceType OriginType { get; set; }
    public List<OfferSliceSegment> Segments { get; set; }
}
