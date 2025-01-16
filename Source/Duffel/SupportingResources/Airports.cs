using System.Collections.Generic;
using System.Threading.Tasks;


    /// <summary>
    /// Airports are used to identify origins and destinations in journey slices.
    /// </summary>
    public class Airports : Resource
    {
        /// <summary>
        /// Endpoint path.
        /// </summary>
        private readonly string _path;

        public Airports(Client client) : base(client)
        {
            _path = "air/airports";
        }

        /// <summary>
        /// Retrieves an airport by its ID.
        /// </summary>
        /// <param name="id">Duffel's unique identifier for the airport.</param>
        /// <returns>The airport details.</returns>
        public async Task<Airport> GetAsync(string id)
        {
            var response = await RequestAsync<Airport>(HttpMethod.Get, $"{_path}/{id}");
            return response.Data;
        }

        /// <summary>
        /// Retrieves a page of airports. The results may be returned in any order.
        /// </summary>
        /// <param name="pagination">Pagination options (optional: limit, after, before).</param>
        /// <returns>A list of airports.</returns>
        public async Task<List<Airport>> ListAsync(PaginationMeta pagination = null)
        {
            var response = await RequestAsync<List<Airport>>(HttpMethod.Get, _path, pagination);
            return response.Data;
        }

        /// <summary>
        /// Retrieves a generator of all airports. The results may be returned in any order.
        /// </summary>
        /// <returns>An asynchronous enumerable of airports.</returns>
        public async IAsyncEnumerable<Airport> ListWithGeneratorAsync()
        {
            await foreach (var airport in PaginatedRequestAsync<Airport>(_path))
            {
                yield return airport.Data;
            }
        }
    }
