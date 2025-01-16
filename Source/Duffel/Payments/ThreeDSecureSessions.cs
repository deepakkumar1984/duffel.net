using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ThreeDSecureSessions : Resource
{
    private readonly string _path;

    public ThreeDSecureSessions(Client client) : base(client)
    {
        _path = "payments/three_d_secure_sessions";
    }

    /// <summary>
    /// Create a Duffel ThreeDSecureSession record.
    /// </summary>
    /// <param name="data">The parameters for creating a ThreeDSecureSession.</param>
    /// <returns>A DuffelResponse containing the ThreeDSecureSession record.</returns>
    public async Task<DuffelResponse<ThreeDSecureSessionRecord>> CreateAsync(ThreeDSecureSessionParameters data)
    {
        return await RequestAsync<ThreeDSecureSessionRecord>("POST", _path, data);
    }
}

public class ThreeDSecureSessionParameters
{
    /// <summary>
    /// The offer ID, order ID, order change ID or quote ID intended to pay.
    /// </summary>
    public string ResourceId { get; set; }

    /// <summary>
    /// The services intended to pay.
    /// </summary>
    public List<Service> Services { get; set; }

    /// <summary>
    /// The card ID.
    /// </summary>
    public string CardId { get; set; }

    /// <summary>
    /// The exception name for the 3DS session.
    /// </summary>
    public string Exception { get; set; }
}

public class ThreeDSecureSessionRecord
{
    public string Id { get; set; }
    public string ResourceId { get; set; }
    public string CardId { get; set; }
    public bool LiveMode { get; set; }
    public DateTime ExpiresAt { get; set; }
    public string Status { get; set; }
    public string ClientId { get; set; }
}

public class Service
{
    /// <summary>
    /// The quantity of the service ID to pay for.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// The ID of the service to pay for.
    /// </summary>
    public string Id { get; set; }
}
