using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Offers : Resource
{
    private readonly string _path;

    public Offers(Client client) : base(client)
    {
        _path = "air/offers";
    }

    /// <summary>
    /// Retrieves an offer by its ID.
    /// </summary>
    /// <param name="id">Duffel's unique identifier for the offer.</param>
    /// <param name="returnAvailableServices">Whether to include available services in the response.</param>
    /// <returns>The specified offer.</returns>
    public async Task<DuffelResponse<Offer>> GetAsync(string id, bool? returnAvailableServices = null)
    {
        var queryParams = returnAvailableServices.HasValue
            ? new Dictionary<string, object> { { "return_available_services", returnAvailableServices.Value.ToString().ToLower() } }
            : null;

        return await RequestAsync<Offer>(HttpMethod.Get, $"{_path}/{id}", queryParams);
    }

    /// <summary>
    /// Retrieves a page of offers for a specified offer request ID.
    /// </summary>
    /// <param name="offerRequestId">Duffel's unique identifier for the offer request.</param>
    /// <param name="parameters">Optional parameters for pagination, sorting, and filtering.</param>
    /// <returns>A page of offers.</returns>
    public async Task<DuffelResponse<List<Offer>>> ListAsync(string offerRequestId, Dictionary<string, object> parameters = null)
    {
        parameters ??= new Dictionary<string, object>();
        parameters["offer_request_id"] = offerRequestId;

        return await RequestAsync<List<Offer>>(HttpMethod.Get, _path, parameters);
    }

    /// <summary>
    /// Retrieves a generator for all offers for a specified offer request ID.
    /// </summary>
    /// <param name="offerRequestId">Duffel's unique identifier for the offer request.</param>
    /// <param name="parameters">Optional parameters for pagination, sorting, and filtering.</param>
    /// <returns>An asynchronous generator of offers.</returns>
    public async IAsyncEnumerable<Offer> ListWithGeneratorAsync(string offerRequestId, Dictionary<string, object> parameters = null)
    {
        parameters ??= new Dictionary<string, object>();
        parameters["offer_request_id"] = offerRequestId;

        await foreach (var offer in PaginatedRequestAsync<Offer>(_path, parameters))
        {
            yield return offer.Data;
        }
    }

    /// <summary>
    /// Updates passenger details for a specific offer.
    /// </summary>
    /// <param name="offerId">Duffel's unique identifier for the offer.</param>
    /// <param name="passengerId">The identifier for the passenger.</param>
    /// <param name="parameters">The updated passenger details.</param>
    /// <returns>The updated offer with passenger details.</returns>
    public async Task<DuffelResponse<UpdateOffer>> UpdateAsync(string offerId, string passengerId, UpdateOfferBodyParameters parameters)
    {
        return await RequestAsync<DuffelResponse<UpdateOffer>>(
            HttpMethod.Patch,
            $"{_path}/{offerId}/passengers/{passengerId}",
            parameters
        );
    }
}

public class UpdateOfferBodyParameters
{
    public List<LoyaltyProgrammeAccounts> LoyaltyProgrammeAccounts { get; set; }
    public string GivenName { get; set; }
    public string FamilyName { get; set; }
}
