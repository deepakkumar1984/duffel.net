using System;
using System.Collections.Generic;

public enum StaysBedType
{
    Single,
    Double,
    Queen,
    King,
    Sofabed
}

public class StaysBed
{
    public StaysBedType Type { get; set; }
    public int Count { get; set; }
}

public class StaysRating
{
    public string Source { get; set; }
    public int Value { get; set; }
}

public class StaysRateCondition
{
    public string Description { get; set; }
    public string Title { get; set; }
}

public class StaysRateCancellationTimeline
{
    public string RefundAmount { get; set; }
    public DateTime Before { get; set; }
    public string Currency { get; set; }
}

public enum StaysLoyaltyProgrammeReference
{
    WyndhamRewards,
    ChoicePrivileges,
    MarriottBonvoy,
    BestWesternRewards,
    WorldOfHyatt,
    HiltonHonors,
    IhgOneRewards,
    LeadersClub,
    StashRewards,
    OmniSelectGuest,
    IPrefer,
    AccorLiveLimitless,
    My6,
    JumeirahOne,
    GlobalHotelAllianceDiscovery,
    DuffelHotelGroupRewards
}

public enum StaysPaymentType
{
    Balance,
    Card
}

public class StaysRate
{
    public string BaseAmount { get; set; }
    public string BaseCurrency { get; set; }
    public string BoardType { get; set; }
    public List<StaysRateCancellationTimeline> CancellationTimeline { get; set; }
    public List<StaysRateCondition> Conditions { get; set; }
    public string DueAtAccommodationAmount { get; set; }
    public string DueAtAccommodationCurrency { get; set; }
    public string Id { get; set; }
    public string PaymentType { get; set; }
    public string Supplier { get; set; }
    public string FeeAmount { get; set; }
    public string FeeCurrency { get; set; }
    public string TaxAmount { get; set; }
    public string TaxCurrency { get; set; }
    public string TotalAmount { get; set; }
    public string TotalCurrency { get; set; }
    public List<StaysPaymentType> AvailablePaymentMethods { get; set; }
    public StaysLoyaltyProgrammeReference? SupportedLoyaltyProgramme { get; set; }
    public string Source { get; set; }
}

public class StaysRoomRate : StaysRate
{
    public int? QuantityAvailable { get; set; }
}

public class StaysPhoto
{
    public string Url { get; set; }
}

public class StaysRoom
{
    public string Name { get; set; }
    public List<StaysBed> Beds { get; set; }
    public List<StaysPhoto> Photos { get; set; }
    public List<StaysRoomRate> Rates { get; set; }
}

public class StaysAmenity
{
    public string Type { get; set; }
    public string Description { get; set; }
}

public class StaysChain
{
    public string Name { get; set; }
}

public class StaysAddress
{
    public string CityName { get; set; }
    public string CountryCode { get; set; }
    public string LineOne { get; set; }
    public string PostalCode { get; set; }
    public string Region { get; set; }
}

public class GeographicCoordinates
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}

public class StaysLocation
{
    public StaysAddress Address { get; set; }
    public GeographicCoordinates GeographicCoordinates { get; set; }
}

public class StaysAccommodationBrand
{
    public string Name { get; set; }
    public string Id { get; set; }
}

public class StaysAccommodation
{
    public string Id { get; set; }
    public List<StaysAmenity> Amenities { get; set; }
    public StaysChain Chain { get; set; }
    public StaysAccommodationBrand Brand { get; set; }
    public string Description { get; set; }
    public string Email { get; set; }
    public StaysLocation Location { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public List<StaysPhoto> Photos { get; set; }
    public List<StaysRating> Ratings { get; set; }
    public double? Rating { get; set; }
    public double? ReviewScore { get; set; }
    public List<StaysRoom> Rooms { get; set; }
    public StaysLoyaltyProgrammeReference? SupportedLoyaltyProgramme { get; set; }
}

public class StaysAccommodationSuggestion
{
    public string AccommodationId { get; set; }
    public string AccommodationName { get; set; }
    public StaysLocation AccommodationLocation { get; set; }
}

public class StaysQuote
{
    public string Id { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public StaysAccommodation Accommodation { get; set; }
    public string TotalAmount { get; set; }
    public string TotalCurrency { get; set; }
    public string BaseAmount { get; set; }
    public string BaseCurrency { get; set; }
    public string FeeAmount { get; set; }
    public string FeeCurrency { get; set; }
    public string TaxAmount { get; set; }
    public string TaxCurrency { get; set; }
    public string DueAtAccommodationAmount { get; set; }
    public string DueAtAccommodationCurrency { get; set; }
    public StaysLoyaltyProgrammeReference? SupportedLoyaltyProgramme { get; set; }
    public int Rooms { get; set; }
    public List<Guest> Guests { get; set; }
}

public enum StaysBookingStatus
{
    Confirmed,
    Cancelled
}

public class StaysBookingKeyCollection
{
    public string Instructions { get; set; }
}

public class StaysBooking
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public StaysAccommodation Accommodation { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public string Reference { get; set; }
    public StaysBookingStatus Status { get; set; }
    public DateTime ConfirmedAt { get; set; }
    public DateTime? CancelledAt { get; set; }
    public List<Guest> Guests { get; set; }
    public StaysLoyaltyProgrammeReference? SupportedLoyaltyProgramme { get; set; }
    public string LoyaltyProgrammeAccountNumber { get; set; }
    public int Rooms { get; set; }
    public Dictionary<string, string> Metadata { get; set; }
    public StaysBookingKeyCollection KeyCollection { get; set; }
}

public class Guest
{
    public string Type { get; set; }
    public int? Age { get; set; }
}

public class CommonStaysSearchParams
{
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public int Rooms { get; set; }
    public List<Guest> Guests { get; set; }
}

public class LocationParams
{
    public int Radius { get; set; }
    public GeographicCoordinates GeographicCoordinates { get; set; }
}

public class LocationSearchParams : CommonStaysSearchParams
{
    public LocationParams Location { get; set; }
}

public class AccommodationSearchParams : CommonStaysSearchParams
{
    public List<string> Ids { get; set; }
    public bool FetchRates { get; set; }
}

public class StaysSearchParams
{
    public LocationSearchParams LocationSearch { get; set; }
    public AccommodationSearchParams AccommodationSearch { get; set; }
}

public class ListAccommodationParams
{
    public int? Radius { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}

public class StaysSearchResult
{
    public string Id { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public StaysAccommodation Accommodation { get; set; }
    public int Rooms { get; set; }
    public List<Guest> Guests { get; set; }
    public string CheapestRateTotalAmount { get; set; }
    public string CheapestRateCurrency { get; set; }
}

public class StaysLoyaltyProgramme
{
    public StaysLoyaltyProgrammeReference Reference { get; set; }
    public string Name { get; set; }
    public string LogoUrlSvg { get; set; }
    public string LogoUrlPngSmall { get; set; }
}
