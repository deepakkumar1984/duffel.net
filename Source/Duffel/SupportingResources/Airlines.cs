using Duffel.Api.Clients;

using Duffel.Api.Models.Responses;

    /// <summary>
    /// Airlines are used to identify the air travel companies selling and operating flights.
    /// </summary>
    public class Airlines : Resource
    {
        /// <summary>
        /// Endpoint path
        /// </summary>
        private readonly string _path = "air/airlines";

        public Airlines(Client client) : base(client) { }

        /// <summary>
        /// Retrieves an airline by its ID.
        /// </summary>
        /// <param name="id">Duffel's unique identifier for the airline.</param>
        /// <returns>The airline data.</returns>
        public async Task<DuffelResponse<Airline>> GetAsync(string id)
        {
            return await RequestAsync<DuffelResponse<Airline>>($"{_path}/{id}", HttpMethod.Get);
        }

        /// <summary>
        /// Retrieves a page of airlines. The results may be returned in any order.
        /// </summary>
        /// <param name="pagination">Pagination options (optional: limit, after, before).</param>
        /// <returns>A list of airlines.</returns>
        public async Task<DuffelResponse<List<Airline>>> ListAsync(PaginationMeta pagination = null)
        {
            var queryParams = pagination?.ToQueryString();
            return await RequestAsync<DuffelResponse<List<Airline>>>(_path, HttpMethod.Get, queryParams);
        }

        /// <summary>
        /// Retrieves a generator of all airlines. The results may be returned in any order.
        /// </summary>
        /// <returns>An async enumerable of airlines.</returns>
        public async IAsyncEnumerable<DuffelResponse<Airline>> ListWithGeneratorAsync()
        {
            await foreach (var airline in PaginatedRequestAsync<Airline>(_path))
            {
                yield return airline;
            }
        }
    }
