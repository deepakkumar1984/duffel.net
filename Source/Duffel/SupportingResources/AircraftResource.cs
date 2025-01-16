using System.Collections.Generic;
using System.Threading.Tasks;

using Duffel.Api.Types;

    /// <summary>
    /// Aircraft are used to describe what passengers will fly in for a given trip.
    /// </summary>
    public class AircraftResource : Resource
    {
        /// <summary>
        /// Endpoint path.
        /// </summary>
        private const string Path = "air/aircraft";

        public AircraftResource(Client client) : base(client) { }

        /// <summary>
        /// Retrieves an aircraft by its ID.
        /// </summary>
        /// <param name="id">Duffel's unique identifier for the aircraft.</param>
        /// <returns>A single aircraft.</returns>
        public Task<DuffelResponse<Aircraft>> GetAsync(string id)
        {
            return RequestAsync<Aircraft>(HttpMethod.Get, $"{Path}/{id}");
        }

        /// <summary>
        /// Retrieves a page of aircraft. The results may be returned in any order.
        /// </summary>
        /// <param name="options">Pagination options (optional: limit, after, before).</param>
        /// <returns>A list of aircraft.</returns>
        public Task<DuffelResponse<List<Aircraft>>> ListAsync(PaginationMeta options = null)
        {
            return RequestAsync<DuffelResponse<List<Aircraft>>>(HttpMethod.Get, Path, options);
        }

        /// <summary>
        /// Retrieves a generator of all aircraft. The results may be returned in any order.
        /// </summary>
        /// <returns>An async enumerable of aircraft.</returns>
        public async IAsyncEnumerable<Aircraft> ListWithGeneratorAsync()
        {
            await foreach (var aircraft in PaginatedRequestAsync<Aircraft>(Path))
            {
                yield return aircraft.Data;
            }
        }
    }
