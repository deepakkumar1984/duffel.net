    /// <summary>
    /// Airlines are used to identify the air travel companies selling and operating flights.
    /// </summary>
    public class Airline
    {
        /// <summary>
        /// The name of the airline.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Duffel's unique identifier for the airline.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The two-character IATA code for the airline. This may be null for non-IATA carriers.
        /// </summary>
        public string IataCode { get; set; }

        /// <summary>
        /// Path to an SVG of the airline lockup logo. A lockup logo is also called a combination logo, in which it combines the logotype and logomark. This may be null if no logo is available.
        /// </summary>
        public string LogoLockupUrl { get; set; }

        /// <summary>
        /// Path to an SVG of the airline logo. This may be null if no logo is available.
        /// </summary>
        public string LogoSymbolUrl { get; set; }

        /// <summary>
        /// URL to the airline's conditions of carriage.
        /// </summary>
        public string ConditionsOfCarriageUrl { get; set; }
    }
