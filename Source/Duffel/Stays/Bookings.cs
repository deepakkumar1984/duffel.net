using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Bookings : Resource
{
    private readonly string _path;

    public Bookings(Client client) : base(client)
    {
        _path = "stays/bookings";
    }

    /// <summary>
    /// Create a booking.
    /// </summary>
    /// <param name="payload">The booking payload, including quote ID and guest information.</param>
    /// <returns>A DuffelResponse containing the booking details.</returns>
    public async Task<DuffelResponse<StaysBooking>> CreateAsync(StaysBookingPayload payload)
    {
        return await RequestAsync<StaysBooking>("POST", _path, payload);
    }

    /// <summary>
    /// Get a booking by ID.
    /// </summary>
    /// <param name="bookingId">The ID of the booking.</param>
    /// <returns>A DuffelResponse containing the booking details.</returns>
    public async Task<DuffelResponse<StaysBooking>> GetAsync(string bookingId)
    {
        return await RequestAsync<StaysBooking>("GET", $"{_path}/{bookingId}");
    }

    /// <summary>
    /// List bookings with optional pagination options.
    /// </summary>
    /// <param name="options">Pagination options (limit, after, before).</param>
    /// <returns>A DuffelResponse containing a list of bookings.</returns>
    public async Task<DuffelResponse<List<StaysBooking>>> ListAsync(PaginationMeta options = null)
    {
        return await RequestAsync<List<StaysBooking>>("GET", _path, options);
    }

    /// <summary>
    /// Retrieves a generator of all bookings. The results may be returned in any order.
    /// </summary>
    /// <returns>An asynchronous generator of bookings.</returns>
    public async IAsyncEnumerable<DuffelResponse<StaysBooking>> ListWithGeneratorAsync()
    {
        await foreach (var response in PaginatedRequestAsync<StaysBooking>(_path))
        {
            yield return response;
        }
    }

    /// <summary>
    /// Cancel a booking by ID.
    /// </summary>
    /// <param name="bookingId">The ID of the booking.</param>
    /// <returns>A DuffelResponse containing the cancelled booking details.</returns>
    public async Task<DuffelResponse<StaysBooking>> CancelAsync(string bookingId)
    {
        return await RequestAsync<StaysBooking>("POST", $"{_path}/{bookingId}/actions/cancel");
    }
}

public class StaysBookingPayload
{
    public string QuoteId { get; set; }
    public string LoyaltyProgrammeAccountNumber { get; set; }
    public List<Guest> Guests { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string AccommodationSpecialRequests { get; set; }
    public Payment Payment { get; set; }
}

public class Guest
{
    public string GivenName { get; set; }
    public string FamilyName { get; set; }
}

public class Payment
{
    public string CardId { get; set; }
    public string ThreeDSecureSessionId { get; set; }
}

public class StaysBooking
{
    public string Id { get; set; }
    public string Status { get; set; }
    // Add other properties as needed
}

