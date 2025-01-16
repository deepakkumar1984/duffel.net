using System;
using System.Collections.Generic;

public enum AcceptedCurrencies
{
    AUD,
    CAD,
    EUR,
    GBP,
    USD
}

public enum LegalEntityType
{
    Corporation,
    NonProfit,
    Other,
    Partnership,
    SoleProprietorship
}

public enum PersonalAccessTokenRole
{
    Roles_User_Personal
}

public enum SourceOfFunds
{
    CapitalInvested,
    Debt,
    Other,
    Revenue
}

public enum TokenRole
{
    Roles_Api_ReadWrite,
    Roles_Api_ReadOnly
}

public enum UserRole
{
    Roles_Duffel_TravelOps,
    Roles_User_Admin,
    Roles_User_Agent,
    Roles_User_Developer,
    Roles_User_Owner,
    Roles_User_Viewer,
    Roles_User_Personal
}

public enum VerificationFlow
{
    Duffel2020,
    StripeConnect
}

public class AccessToken
{
    public DateTime CreatedAt { get; set; }
    public DateTime ExpiresAt { get; set; }
    public string Id { get; set; }
    public DateTime? LastUsedAt { get; set; }
    public string LastVersionUsed { get; set; }
    public bool? LiveMode { get; set; }
    public string Name { get; set; }
    public TokenRole Scope { get; set; }
    public string Token { get; set; }
}

public class Invitation
{
    public DateTime? AcceptedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ExpiresAt { get; set; }
    public string Id { get; set; }
    public Organisation Organisation { get; set; }
    public string OrganisationId { get; set; }
    public User Recipient { get; set; }
    public string RecipientEmail { get; set; }
    public string RecipientId { get; set; }
    public DateTime? RevokedAt { get; set; }
    public UserRole Scope { get; set; }
    public User Sender { get; set; }
    public string SenderId { get; set; }
    public DateTime SentAt { get; set; }
    public string Token { get; set; }
}

public class Organisation
{
    public List<AccessToken> AccessTokens { get; set; }
    public string AvatarUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Id { get; set; }
    public string Name { get; set; }
    public AcceptedCurrencies SettlementCurrency { get; set; }
    public string Slug { get; set; }
    public bool? Verified { get; set; }
    public LegalEntity LegalEntity { get; set; }
    public string StripeCustomerId { get; set; }
    public string StripePaymentMethodId { get; set; }
    public VerificationFlow VerificationFlow { get; set; }
    public List<string> ContactEmails { get; set; }
    public List<string> ScheduleChangeEmails { get; set; }
    public bool IsDuffelLinksEnabled { get; set; }
    public string StaysAccessStatus { get; set; }
    public int? PasswordExpiryTimeoutDays { get; set; }
    public int SessionExpiryTimeout { get; set; }
}

public class OrganisationMembership
{
    public string AvatarUrl { get; set; }
    public string Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DisabledAt { get; set; }
    public string OrganisationId { get; set; }
    public bool? Owner { get; set; }
    public UserRole Scope { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
}

public class User
{
    public string AvatarUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool? DuffelAdmin { get; set; }
    public string Email { get; set; }
    public DateTime? EmailConfirmedAt { get; set; }
    public string FullName { get; set; }
    public string Id { get; set; }
    public List<Invitation> OrganisationInvitations { get; set; }
    public List<UserOrganisationMembership> OrganisationMemberships { get; set; }
    public string UnconfirmedEmail { get; set; }
    public List<PersonalAccessToken> TemporaryPersonalAccessTokens { get; set; }
    public bool SendMarketingEmails { get; set; }
}

public class PersonalAccessToken
{
    public DateTime CreatedAt { get; set; }
    public DateTime ExpiresAt { get; set; }
    public string Id { get; set; }
    public DateTime? LastUsedAt { get; set; }
    public string LastVersionUsed { get; set; }
    public bool LiveMode { get; set; }
    public string Name { get; set; }
    public PersonalAccessTokenRole Scope { get; set; }
    public string Token { get; set; }
}

public class UserOrganisationMembership : OrganisationMembership
{
    public Organisation Organisation { get; set; }
}

public class LegalEntity
{
    public string Name { get; set; }
    public LegalEntityType Type { get; set; }
    public string TypeExtra { get; set; }
    public string TradingName { get; set; }
    public string RegisteredBusinessAddressLine1 { get; set; }
    public string RegisteredBusinessAddressLine2 { get; set; }
    public string RegisteredBusinessAddressCity { get; set; }
    public string RegisteredBusinessAddressRegion { get; set; }
    public string RegisteredBusinessAddressPostalCode { get; set; }
    public string RegisteredBusinessAddressCountryCode { get; set; }
    public string RegistrationNumber { get; set; }
    public string RegistrationCountryCode { get; set; }
    public string TaxIdentificationNumber { get; set; }
    public string KeyContactFirstName { get; set; }
    public string KeyContactLastName { get; set; }
    public string KeyContactJobTitle { get; set; }
    public string KeyContactEmail { get; set; }
    public SourceOfFunds InitialTopUpSourceOfFunds { get; set; }
    public string InitialTopUpSourceOfFundsDescription { get; set; }
}
