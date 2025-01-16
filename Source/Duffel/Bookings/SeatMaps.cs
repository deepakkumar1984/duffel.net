
using Duffel.Api.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

    public class SeatMaps : Resource
    {
        public SeatMaps(Client client) : base(client)
        {
            Path = "air/seat_maps";
        }

        /// <summary>
        /// Gets seat maps by specific parameters. At the moment we only support querying by an offer ID.
        /// </summary>
        /// <param name="offerId">Duffel's unique identifier for the offer</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the seat maps.</returns>
        public async Task<DuffelResponse<List<SeatMap>>> GetAsync(string offerId)
        {
            var parameters = new Dictionary<string, string>
            {
                { "offer_id", offerId }
            };

            return await RequestAsync<List<SeatMap>>(HttpMethod.Get, Path, parameters);
        }
    }
