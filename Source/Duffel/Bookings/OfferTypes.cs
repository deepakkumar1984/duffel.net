using System;
using System.Collections.Generic;

public class Offer
{
    public List<OfferAvailableService> AvailableServices { get; set; }
    public string BaseAmount { get; set; }
    public string BaseCurrency { get; set; }
    public FlightsConditions Conditions { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ExpiresAt { get; set; }
    public string Id { get; set; }
    public bool LiveMode { get; set; }
    public Airline Owner { get; set; }
    public bool PassengerIdentityDocumentsRequired { get; set; }
    public List<OfferPassenger> Passengers { get; set; }
    public PaymentRequirements PaymentRequirements { get; set; }
    public List<OfferPrivateFare> PrivateFares { get; set; }
    public List<OfferSlice> Slices { get; set; }
    public string TaxAmount { get; set; }
    public string TaxCurrency { get; set; }
    public string TotalAmount { get; set; }
    public string TotalEmissionsKg { get; set; }
    public string TotalCurrency { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool Partial { get; set; }
    public List<string> SupportedLoyaltyProgrammes { get; set; }
    public List<string> SupportedPassengerIdentityDocumentTypes { get; set; }
}

public class OfferAvailableService
{
    public string Id { get; set; }
    public int MaximumQuantity { get; set; }
    public List<string> PassengerIds { get; set; }
    public List<string> SegmentIds { get; set; }
    public string TotalAmount { get; set; }
    public string TotalCurrency { get; set; }
    public OfferAvailableServiceMetadata Metadata { get; set; }
    public string Type { get; set; }
}

public class OfferAvailableServiceMetadata
{
    public int? MaximumWeightKg { get; set; }
    public int? MaximumHeightCm { get; set; }
    public int? MaximumLengthCm { get; set; }
    public int? MaximumDepthCm { get; set; }
}

public class PaymentRequirements
{
    public DateTime? PaymentRequiredBy { get; set; }
    public DateTime? PriceGuaranteeExpiresAt { get; set; }
    public bool RequiresInstantPayment { get; set; }
}

public class OfferPrivateFare
{
    public string CorporateCode { get; set; }
    public string TrackingReference { get; set; }
    public string Type { get; set; }
}

public class OfferPassenger
{
    public int? Age { get; set; }
    public string Type { get; set; }
    public string FamilyName { get; set; }
    public string GivenName { get; set; }
    public List<LoyaltyProgrammeAccount> LoyaltyProgrammeAccounts { get; set; }
    public string Id { get; set; }
    public string FareType { get; set; }
}

public class OfferSlice
{
    public string DestinationType { get; set; }
    public Place Destination { get; set; }
    public string OriginType { get; set; }
    public Place Origin { get; set; }
    public string Duration { get; set; }
    public string FareBrandName { get; set; }
    public string Id { get; set; }
    public List<OfferSliceSegment> Segments { get; set; }
    public OfferSliceConditions Conditions { get; set; }
    public int? NgsShelf { get; set; }
}

public class OfferSliceSegment
{
    public Aircraft Aircraft { get; set; }
    public DateTime ArrivingAt { get; set; }
    public string DestinationTerminal { get; set; }
    public DateTime DepartingAt { get; set; }
    public string OriginTerminal { get; set; }
    public Airport Destination { get; set; }
    public string Distance { get; set; }
    public string Duration { get; set; }
    public string Id { get; set; }
    public Airline MarketingCarrier { get; set; }
    public string MarketingCarrierFlightNumber { get; set; }
    public Airport Origin { get; set; }
    public Airline OperatingCarrier { get; set; }
    public string OperatingCarrierFlightNumber { get; set; }
    public List<OfferSliceSegmentPassenger> Passengers { get; set; }
    public List<Stop> Stops { get; set; }
}

public class OfferSliceSegmentPassenger
{
    public List<OfferSliceSegmentPassengerBaggage> Baggages { get; set; }
    public string CabinClass { get; set; }
    public string CabinClassMarketingName { get; set; }
    public string PassengerId { get; set; }
    public string FareBasisCode { get; set; }
    public OfferSliceSegmentPassengerCabin Cabin { get; set; }
}

public class OfferSliceSegmentPassengerCabin
{
    public string Name { get; set; }
    public string MarketingName { get; set; }
    public CabinAmenities Amenities { get; set; }
}

public class CabinAmenities
{
    public WiFi Wifi { get; set; }
    public Seat Seat { get; set; }
    public Power Power { get; set; }
}

public class WiFi
{
    public bool Available { get; set; }
    public string Cost { get; set; }
}

public class Seat
{
    public string Pitch { get; set; }
    public string Type { get; set; }
}

public class Power
{
    public bool Available { get; set; }
}

public class OfferSliceSegmentPassengerBaggage
{
    public string Type { get; set; }
    public int Quantity { get; set; }
}
