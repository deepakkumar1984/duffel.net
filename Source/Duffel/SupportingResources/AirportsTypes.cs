

    /// <summary>
    /// Airports are used to identify origins and destinations in journey slices.
    /// </summary>
    public class Airport
    {
        /// <summary>
        /// The metropolitan area where the airport is located.
        /// Only present for airports which are registered with IATA as belonging to a metropolitan area.
        /// </summary>
        public City City { get; set; }

        /// <summary>
        /// The name of the city (or cities separated by a `/`) where the airport is located.
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// The three-character IATA code for the airport.
        /// </summary>
        public string IataCode { get; set; }

        /// <summary>
        /// The ISO 3166-1 alpha-2 code for the country where the city is located.
        /// </summary>
        /// <example>GB</example>
        public string IataCountryCode { get; set; }

        /// <summary>
        /// The 3-letter IATA code for the city where the place is located.
        /// Only present for airports which are registered with IATA as belonging to a metropolitan area.
        /// </summary>
        public string IataCityCode { get; set; }

        /// <summary>
        /// The four-character ICAO code for the airport.
        /// </summary>
        public string IcaoCode { get; set; }

        /// <summary>
        /// Duffel's unique identifier for the airport.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The latitude position of the airport represented in Decimal degrees with 6 decimal points with a range between -90° and 90°.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// The longitude position of the airport represented in Decimal degrees with 6 decimal points with a range between -180° and 180°.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// The name of the airport.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The time zone of the airport, specified by name from the tz database.
        /// </summary>
        public string TimeZone { get; set; }

        /// <summary>
        /// The type of the place.
        /// </summary>
        public string Type { get; set; }
    }
