
using System;
using System.Collections.Generic;
using System.Security.AccessControl;

public class OfferRequestSlice
{
    public string DepartureDate { get; set; }
    public Place Destination { get; set; }
    public Place Origin { get; set; }
    public string OriginType { get; set; }
    public string DestinationType { get; set; }
}

public class LoyaltyProgrammeAccount
{
    public string AccountNumber { get; set; }
    public string AirlineIataCode { get; set; }
}

public class CreateOfferRequestPassengerCommon
{
    public string FamilyName { get; set; }
    public string GivenName { get; set; }
    public List<LoyaltyProgrammeAccount> LoyaltyProgrammeAccounts { get; set; }
}

public class CreateOfferRequestAdultPassenger : CreateOfferRequestPassengerCommon
{
    public string Type { get; set; } = "adult";
}

public class CreateOfferRequestNonAdultPassenger : CreateOfferRequestPassengerCommon
{
    public int Age { get; set; }
}

public class CreateOfferRequestPassengerWithFareType : CreateOfferRequestPassengerCommon
{
    public int? Age { get; set; }
    public string FareType { get; set; }
}

public class CreateOfferRequestPrivateFare
{
    public string CorporateCode { get; set; }
    public string TrackingReference { get; set; }
}

public class OfferRequestPassenger
{
    public int? Age { get; set; }
    public string Type { get; set; }
    public string FamilyName { get; set; }
    public string GivenName { get; set; }
    public List<LoyaltyProgrammeAccount> LoyaltyProgrammeAccounts { get; set; }
    public string Id { get; set; }
}

public class OfferRequest
{
    public List<OfferRequestSlice> Slices { get; set; }
    public string CabinClass { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Id { get; set; }
    public bool LiveMode { get; set; }
    public List<Offer> Offers { get; set; }
    public List<OfferRequestPassenger> Passengers { get; set; }
}

public class CreateOfferRequest
{
    public string CabinClass { get; set; }
    public int? MaxConnections { get; set; }
    public List<CreateOfferRequestPassengerCommon> Passengers { get; set; }
    public Dictionary<string, List<CreateOfferRequestPrivateFare>> PrivateFares { get; set; }
    public List<CreateOfferRequestSlice> Slices { get; set; }
}

public class CreateOfferRequestSlice
{
    public string Destination { get; set; }
    public string Origin { get; set; }
    public string DepartureDate { get; set; }
    public TimeRangeFilter ArrivalTime { get; set; }
    public TimeRangeFilter DepartureTime { get; set; }
}

public class TimeRangeFilter
{
    public string From { get; set; }
    public string To { get; set; }
}

public class CreateOfferRequestQueryParameters
{
    public bool? ReturnOffers { get; set; }
    public int? SupplierTimeout { get; set; }
}
