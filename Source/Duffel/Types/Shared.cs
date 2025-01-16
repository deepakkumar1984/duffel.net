using System;
using System.Collections.Generic;

    public class City
    {
        public string IataCode { get; set; }
        public string IataCountryCode { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Airport> Airports { get; set; }
        public string Type { get; set; } = "city";
    }

    public class CabinClass
    {
        public const string First = "first";
        public const string Business = "business";
        public const string PremiumEconomy = "premium_economy";
        public const string Economy = "economy";
    }

    public class PassengerType
    {
        public const string Adult = "adult";
        public const string Child = "child";
        public const string InfantWithoutSeat = "infant_without_seat";
    }

    public class DuffelPassengerTitle
    {
        public const string Mr = "mr";
        public const string Ms = "ms";
        public const string Mrs = "mrs";
        public const string Miss = "miss";
        public const string Dr = "dr";
    }

    public class DuffelPassengerGender
    {
        public const string Male = "m";
        public const string Female = "f";
    }

    public class PassengerIdentityDocumentType
    {
        public const string Passport = "passport";
        public const string TaxId = "tax_id";
    }

    public class PlaceType
    {
        public const string Airport = "airport";
        public const string City = "city";
    }

    public class FlightsCondition
    {
        public string PenaltyCurrency { get; set; }
        public string PenaltyAmount { get; set; }
        public bool Allowed { get; set; }
    }

    public class FlightsConditions
    {
        public FlightsCondition RefundBeforeDeparture { get; set; }
        public FlightsCondition ChangeBeforeDeparture { get; set; }
    }

    public class OfferSliceConditions : FlightsConditions
    {
        public bool? AdvanceSeatSelection { get; set; }
        public bool? PriorityBoarding { get; set; }
        public bool? PriorityCheckIn { get; set; }
    }

    public enum PaymentType
    {
        ArcBspCash,
        Balance
    }

