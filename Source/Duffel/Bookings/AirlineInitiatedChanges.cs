using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AirlineInitiatedChanges : Resource
{
    private readonly string _path;

    public AirlineInitiatedChanges(Client client) : base(client)
    {
        _path = "air/airline_initiated_changes";
    }

    /// <summary>
    /// Updates the status of an airline-initiated change with the action taken.
    /// </summary>
    /// <param name="id">The ID of the airline-initiated change.</param>
    /// <param name="actionTaken">The action taken in response to the change (Accepted, Cancelled, Changed).</param>
    /// <returns>A DuffelResponse containing the updated airline-initiated change.</returns>
    public async Task<DuffelResponse<AirlineInitiatedChange>> UpdateAsync(string id, AirlineInitiatedChangeActionTaken actionTaken)
    {
        var data = new { action_taken = actionTaken.ToString().ToLower() };
        return await RequestAsync<AirlineInitiatedChange>("PATCH", $"{_path}/{id}", data);
    }

    /// <summary>
    /// Accepts an airline-initiated change.
    /// </summary>
    /// <param name="id">The ID of the airline-initiated change.</param>
    /// <returns>A DuffelResponse containing the accepted airline-initiated change.</returns>
    public async Task<DuffelResponse<AirlineInitiatedChange>> AcceptAsync(string id)
    {
        return await RequestAsync<AirlineInitiatedChange>("POST", $"{_path}/{id}/actions/accept");
    }

    /// <summary>
    /// Retrieves a list of all airline-initiated changes filtered by an order ID.
    /// </summary>
    /// <param name="orderId">The ID of the order to filter changes.</param>
    /// <returns>A DuffelResponse containing a list of airline-initiated changes for the order.</returns>
    public async Task<DuffelResponse<List<AirlineInitiatedChange>>> ListAsync(string orderId)
    {
        var parameters = new { order_id = orderId };
        return await RequestAsync<List<AirlineInitiatedChange>>("GET", _path, parameters);
    }
}
