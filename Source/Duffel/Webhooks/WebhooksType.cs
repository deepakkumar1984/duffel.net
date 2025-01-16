
using Duffel.Api.Responses;
using System.Collections.Generic;

    public class Webhook
    {
        /// <summary>
        /// Whether the webhook receiver is actively being notified or not
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// The ISO 8601 datetime at which the webhook was created
        /// </summary>
        public string CreatedAt { get; set; }

        /// <summary>
        /// The events that this webhook will be subscribed to
        /// </summary>
        public List<string> Events { get; set; }

        /// <summary>
        /// Duffel's unique identifier for the webhook receiver
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The live mode that the webhook was created in. It will only receive events for that same live mode.
        /// </summary>
        public bool LiveMode { get; set; }

        /// <summary>
        /// The ISO 8601 datetime at which the webhook was last updated
        /// </summary>
        public string UpdatedAt { get; set; }

        /// <summary>
        /// The URL where your webhook will be received
        /// </summary>
        public string Url { get; set; }
    }

    public class WebhooksListDeliveriesParams : PaginationMeta
    {
        public bool DeliverySuccess { get; set; }

        /// <summary>
        /// Filters the returned webhook deliveries by creation datetime.
        /// </summary>
        public PaginationMeta CreatedAt { get; set; }

        /// <summary>
        /// Filters webhook deliveries by the type of their related webhook event.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Filters webhook deliveries by the ID of the related webhook endpoint.
        /// </summary>
        public string EndpointId { get; set; }
    }

    public class WebhooksUpdateParams
    {
        public bool Active { get; set; }
        public List<string> Events { get; set; }
        public string Url { get; set; }
    }

    public class WebhooksCreateParams
    {
        public List<string> Events { get; set; }
        public string Url { get; set; }
    }

    public class WebhooksListDeliveriesResponse
    {
        public string Url { get; set; }
        public string EndpointId { get; set; }
        public bool? DeliverySuccess { get; set; }
        public string Type { get; set; }
        public int ResponseStatusCode { get; set; }
        public string ResponseBody { get; set; }
        public string EventId { get; set; }
        public bool LiveMode { get; set; }
        public string Id { get; set; }
        public string CreatedAt { get; set; }
    }

    public class WebhooksListResponse : Webhook
    {
        public bool? DeliverySuccess { get; set; }
    }

    public class WebhooksCreateResponse
    {
        public string Secret { get; set; }
        public string Url { get; set; }
        public string UpdatedAt { get; set; }
        public bool LiveMode { get; set; }
        public string Id { get; set; }
        public List<string> Events { get; set; }
        public string CreatedAt { get; set; }
        public bool Active { get; set; }
    }
