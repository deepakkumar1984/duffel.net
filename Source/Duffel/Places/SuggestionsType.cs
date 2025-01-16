using System;
using System.Collections.Generic;

public class Place
{
    /// <summary>
    /// The type of the place.
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// The time zone of the airport, specified by name from the tz database.
    /// </summary>
    public string TimeZone { get; set; }

    /// <summary>
    /// The name of the place.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The longitude position of the airport represented in Decimal degrees with 6 decimal points.
    /// </summary>
    public double? Longitude { get; set; }

    /// <summary>
    /// The latitude position of the airport represented in Decimal degrees with 6 decimal points.
    /// </summary>
    public double? Latitude { get; set; }

    /// <summary>
    /// Duffel's unique identifier for the place.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// The four-character ICAO code for the airport.
    /// </summary>
    public string IcaoCode { get; set; }

    /// <summary>
    /// The ISO 3166-1 alpha-2 code for the country where the city is located.
    /// </summary>
    public string IataCountryCode { get; set; }

    /// <summary>
    /// The 3-letter IATA code for the place.
    /// </summary>
    public string IataCode { get; set; }

    /// <summary>
    /// The 3-letter IATA code for the city where the place is located. Only present for airports registered with IATA as belonging to a metropolitan area.
    /// </summary>
    public string IataCityCode { get; set; }

    /// <summary>
    /// The name of the country where the city or airport is located.
    /// </summary>
    public string CountryName { get; set; }

    /// <summary>
    /// The name of the city (or cities separated by a /) where the airport is located.
    /// </summary>
    public string CityName { get; set; }

    /// <summary>
    /// The metropolitan area where the airport is located. Only present for airports registered with IATA as belonging to a metropolitan area.
    /// </summary>
    public City City { get; set; }

    /// <summary>
    /// The airports associated with a city. This will only be provided where the type is city.
    /// </summary>
    public List<Airport> Airports { get; set; }
}

public class City
{
    /// <summary>
    /// The name of the city.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The Duffel unique identifier for the city.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// The IATA code for the city.
    /// </summary>
    public string IataCode { get; set; }

    /// <summary>
    /// The country code for the city.
    /// </summary>
    public string CountryCode { get; set; }
}

public class Airport
{
    /// <summary>
    /// The name of the airport.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The IATA code for the airport.
    /// </summary>
    public string IataCode { get; set; }

    /// <summary>
    /// The ICAO code for the airport.
    /// </summary>
    public string IcaoCode { get; set; }

    /// <summary>
    /// The location latitude.
    /// </summary>
    public double Latitude { get; set; }

    /// <summary>
    /// The location longitude.
    /// </summary>
    public double Longitude { get; set; }
}
