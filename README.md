# Duffel API .NET Client

The Duffel .NET client library makes it easy to interact with the Duffel API from your server-side .NET applications.

## Content

- [Requirements](#requirements)
- [Installation](#installation)
- [Usage](#usage)
- [Configuration](#configuration)
- [Contributing](docs/CONTRIBUTING.md)
- [Documentation](#documentation)

## Requirements

To use the Duffel .NET client library, you'll need **.NET Core 8** or later.

## Usage

To get started, import the `DuffelClient` class into your code and initialize it using your access token, which you can get from the "Access tokens" page in your [Duffel dashboard](http://app.duffel.com/):

```csharp
var duffelClient = new DuffelClient("your_access_token");

// To quickly test whether your integration is working, you can get a single aircraft by its Duffel ID
var aircraft = await duffelClient.Aircraft.GetAsync("arc_00009VMF8AhXSSRnQDI6Hi");
Console.WriteLine(aircraft);
```

### Getting a single object

As a general rule, you get a single object from the API by its ID.

```csharp
var aircraft = await duffelClient.Aircraft.GetAsync("arc_00009VMF8AhXSSRnQDI6Hi");
```

Sometimes, you can pass in optional query parameters:

```csharp
var offer = await duffelClient.Offers.GetAsync("offer_id", returnAvailableServices: true);
```

If your request was successful, the method will return the response object. Inside the `Data` property, you'll find the resource you requested.

```csharp
var aircraft = await duffelClient.Aircraft.GetAsync("arc_00009VMF8AhXSSRnQDI6Hi");
Console.WriteLine(aircraft.Data);
```

Expected output from `Console.WriteLine(aircraft.Data)`:

```json
{
  "name": "Airbus Industries A380",
  "id": "arc_00009UhD4ongolulWd91Ky",
  "iata_code": "380"
}
```

#### Errors

If there are any errors with your request, the client library will throw an exception. The exception will contain details about the error [information](https://duffel.com/docs/api/overview/errors) returned by the API.

You'll find information about what was wrong in the `Errors` property, and useful context like the `Status` and `RequestId` (which you should use when contacting the Duffel support team) inside the `Meta` property.

```csharp
try
{
    var test = await duffelClient.Aircraft.GetAsync("nonexistent_id");
    // The request failed, so we won't hit this
    Console.WriteLine(test);
}
catch (DuffelApiException ex)
{
    Console.WriteLine(ex.Message);
}
```

Expecting output from `Console.WriteLine(ex.Message)` similar to:

```json
{
  "meta": { "status": 404, "request_id": "Fn6SwqLT_Isf3CAAAEah" },
  "errors": [
    {
      "type": "invalid_request_error",
      "title": "Not found",
      "message": "The resource you are trying to access does not exist.",
      "documentation_url": "https://duffel.com/docs/api/overview/errors",
      "code": "not_found"
    }
  ]
}
```

### Listing objects

Our "List" APIs only return a set number of results by default. You can find out more about pagination in the Duffel API in general [here](https://duffel.com/docs/api/overview/pagination). In the client library, we provide two ways to use list endpoints - one that allows you to take advantage of automatic pagination, and one that allows you to paginate manually.

#### Automatic Pagination

We recommend automatic pagination. You can use async enumerables to auto-paginate through all the results with our `ListAllAsync` method.

```csharp
await foreach (var airline in duffelClient.Airlines.ListAllAsync())
{
    Console.WriteLine(airline.Data);
    /* Expecting output similar to:
     * {
     *   "name": "British Airways",
     *   "id": "aln_00001876aqC8c5umZmrRds",
     *   "iata_code": "BA"
     * }
     */
}

// Alternatively, you can iterate one by one
await using var aircraftEnumerator = duffelClient.Aircraft.ListAllAsync().GetAsyncEnumerator();
if (await aircraftEnumerator.MoveNextAsync())
{
    Console.WriteLine(aircraftEnumerator.Current.Data);
    /* Expecting output similar to:
     * {
     *   "name": "Airbus Industries A380",
     *   "id": "arc_00009UhD4ongolulWd91Ky",
     *   "iata_code": "380"
     * }
     */
}
```

#### Manual pagination

Alternatively, you can paginate manually. The `ListAsync` method simply returns the page of the API you've requested, with the metadata that you need to then request the next (or previous) page inside `Meta`.

```csharp
var firstPage = await duffelClient.Airlines.ListAsync();
Console.WriteLine(firstPage);
/* Expected output:
 * {
 *   data: [{
 *     name: "Airbus Industries A380",
 *     id: "arc_00009UhD4ongolulWd91Ky",
 *     iata_code: "380"
 *   }, ...],
 *   meta: {
 *     limit: 50,
 *     before: null,
 *     after: "g3QAAAACZAACaWRtAAAAGmFybF8wMDAwOVZNRTdEQUdpSmp3b21odjJ6ZAAEbmFtZW0AAAAPQWJlbGFnIEF2aWF0aW9u"
 *   }
 * }
 */

// You can then manually paginate by passing in the relevant query parameters
var nextPage = await duffelClient.Airlines.ListAsync(new ListOptions
{
    Limit = firstPage.Meta.Limit,
    After = firstPage.Meta.After,
});
Console.WriteLine(nextPage);
```

### Creating objects

Typically, you'll create a resource by passing in the relevant request body. In some cases, you can pass in relevant query parameters too.

```csharp
var offerRequestResponse = await duffelClient.OfferRequests.CreateAsync(new CreateOfferRequest
{
    Slices = new List<OfferRequestSlice>
    {
        new OfferRequestSlice
        {
            Origin = "NYC",
            Destination = "ATL",
            DepartureDate = DateTime.Parse("2021-06-21")
        }
    },
    Passengers = new List<OfferRequestPassenger>
    {
        new OfferRequestPassenger
        {
            Type = "adult"
        }
    },
    CabinClass = "economy",
    ReturnOffers = false
});

Console.WriteLine(offerRequestResponse.Data.Id);
```

### Actions

On certain endpoints you can perform actions, such as confirming an order cancellation. Usually you'll do that by just passing in the ID.

```csharp
var orderCancellationResponse = await duffelClient.OrderCancellations.ConfirmAsync(orderCancellationId);
Console.WriteLine(orderCancellationResponse.Data.Id);
```

### Update

On certain endpoints you can perform updates, such as updating an order. Usually you'll do that by passing the object ID with the object data changes.

```csharp
var orderUpdateResponse = await duffelClient.Orders.UpdateAsync("ord_00009hthhsUZ8W4LxQgkjo", new UpdateOrderRequest
{
    Metadata = new Dictionary<string, string>
    {
        ["payment_intent_id"] = "pit_00009htYpSCXrwaB9DnUm2"
    }
});

Console.WriteLine(orderUpdateResponse.Data.Id);
```

And if you want to clear metadata:

```csharp
var orderUpdateResponse = await duffelClient.Orders.UpdateAsync("ord_00009hthhsUZ8W4LxQgkjo", new UpdateOrderRequest
{
    Metadata = new Dictionary<string, string>()
});

Console.WriteLine(orderUpdateResponse.Data.Id);
```

## Configuration

### Test and live mode

To use the Duffel test mode, make sure you're using a "test" token. And for live mode, make sure to use a "live" token.

### Timeouts

In the future we plan to make timeouts configurable, but at the moment the library does not yet support that. You can read more about the API response times [here](https://duffel.com/docs/api/overview/response-times).

### Logging

We currently provide some basic logging in the library, and there are plans to add more telemetry options in the future. You can enable verbose logging if you want to check what endpoints are being called and with what arguments.

```csharp
var duffelClient = new DuffelClient("your_access_token")
{
    EnableVerboseLogging = true
};
```

## Documentation

You can learn more about the Duffel API and the library in our [documentation](https://duffel.com/docs).
