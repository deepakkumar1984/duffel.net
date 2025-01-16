using System;
using System.Collections.Generic;

public enum AirlineInitiatedChangeActionTaken
{
    Accepted,
    Cancelled,
    Changed
}

public enum AirlineInitiatedChangeAvailableAction
{
    Accept,
    Cancel,
    Change,
    Update
}

public class TravelAgentTicket
{
    public string Id { get; set; }
    public string ExternalTicketId { get; set; }
}

public class AirlineInitiatedChange
{
    /// <summary>
    /// The action taken in response to this airline-initiated change. Accepted,
    /// cancelled and changed reflect your action in accepting the change,
    /// cancelling the order, or changing the order respectively.
    /// </summary>
    public AirlineInitiatedChangeActionTaken? ActionTaken { get; set; }

    /// <summary>
    /// The ISO 8601 datetime at which an action was taken.
    /// </summary>
    public DateTime? ActionTakenAt { get; set; }

    /// <summary>
    /// List of updated slices and segments following the change. These slices
    /// and segments may each have a new ID as a result of the changes.
    /// </summary>
    public List<OrderSlice> Added { get; set; }

    /// <summary>
    /// The available actions you can take on this Airline-Initiated Change through
    /// our API. "Update" means that you can use the update endpoint for an
    /// Airline-Initiated Change.
    /// </summary>
    public List<AirlineInitiatedChangeAvailableAction> AvailableActions { get; set; }

    /// <summary>
    /// The ISO 8601 datetime at which we detected the airline-initiated change.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Duffel's unique identifier for the airline-initiated change.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Duffel's unique identifier for the order.
    /// </summary>
    public string OrderId { get; set; }

    /// <summary>
    /// List of slices and segments as they were before the change.
    /// </summary>
    public List<OrderSlice> Removed { get; set; }

    /// <summary>
    /// The associated Travel Agent Ticket, if any, for this Airline-Initiated Change.
    /// This value will be present for Airline-Initiated changes that take some time to be processed.
    /// </summary>
    public TravelAgentTicket TravelAgentTicket { get; set; }

    /// <summary>
    /// The ISO 8601 datetime at which the airline-initiated change was last updated.
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}

public class OrderSlice
{
    // Define properties for OrderSlice based on the actual schema.
}
