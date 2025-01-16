
using Duffel.Api.Responses;
using Duffel.Api.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

    public class Webhooks : Resource
    {
        /// <summary>
        /// Endpoint path
        /// </summary>
        private readonly string path;

        public Webhooks(Client client) : base(client)
        {
            path = "air/webhooks";
        }

        /// <summary>
        /// Trigger a re-delivery of an event to a webhook.
        /// </summary>
        /// <param name="id">Duffel's unique identifier for the webhook event</param>
        public Task<DuffelResponse<object>> RedeliverAsync(string id)
        {
            return RequestAsync<object>(HttpMethod.POST, $"{path}/events/{id}/actions/redeliver");
        }

        /// <summary>
        /// Send a ping, a "fake event" notification, to a webhook.
        /// </summary>
        /// <param name="id">Duffel's unique identifier for the webhook receiver</param>
        public Task<DuffelResponse<object>> PingAsync(string id)
        {
            return RequestAsync<object>(HttpMethod.POST, $"{path}/{id}/actions/ping");
        }

        /// <summary>
        /// Retrieves a webhook event by its ID.
        /// </summary>
        /// <param name="id">Duffel's unique identifier for the webhook event</param>
        public Task<DuffelResponse<Webhook>> GetAsync(string id)
        {
            return RequestAsync<Webhook>(HttpMethod.Get, $"{path}/events/{id}");
        }

        /// <summary>
        /// Retrieve a paginated list of webhook deliveries.
        /// </summary>
        /// <param name="parameters">Endpoint options</param>
        public Task<DuffelResponse<List<WebhooksListDeliveriesResponse>>> ListDeliveriesAsync(WebhooksListDeliveriesParams parameters)
        {
            return RequestAsync<List<WebhooksListDeliveriesResponse>>(HttpMethod.Get, $"{path}/deliveries", parameters);
        }

        /// <summary>
        /// Delete a webhook.
        /// </summary>
        /// <param name="id">Duffel's unique identifier for the webhook receiver</param>
        public Task DeleteAsync(string id)
        {
            return RequestAsync<object>(HttpMethod.Delete, $"{path}/{id}");
        }

        /// <summary>
        /// Update a webhook.
        /// </summary>
        /// <param name="id">Duffel's unique identifier for the webhook receiver</param>
        /// <param name="parameters">Webhook update parameters</param>
        public Task UpdateAsync(string id, WebhooksUpdateParams parameters)
        {
            return RequestAsync<object>(HttpMethod.Patch, $"{path}/{id}", parameters);
        }

        /// <summary>
        /// Retrieve a paginated list of webhooks.
        /// </summary>
        /// <param name="parameters">Pagination options</param>
        public Task<DuffelResponse<List<WebhooksListResponse>>> ListAsync(PaginationMeta parameters)
        {
            return RequestAsync<List<WebhooksListResponse>>(HttpMethod.Get, path, parameters);
        }

        /// <summary>
        /// Create a webhook.
        /// </summary>
        /// <param name="parameters">Webhook creation parameters</param>
        public Task<DuffelResponse<WebhooksCreateResponse>> CreateAsync(WebhooksCreateParams parameters)
        {
            return RequestAsync<WebhooksCreateResponse>(HttpMethod.Post, path, parameters);
        }
    }
