using Duffel.Api.Types;

    /// Aircraft are used to describe what passengers will fly in for a given trip.
    /// </summary>
    public class Aircraft
    {
        /// <summary>
        /// The name of the aircraft.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Duffel's unique identifier for the aircraft.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The three-character IATA code for the aircraft.
        /// </summary>
        public string IataCode { get; set; }
    }
