using System.Collections.Generic;

/// <summary>
/// Our list APIs will only return a limited number of results at a time.
/// By default, we'll return 50 results per page, but you can set this to any number between 1 and 200.
/// </summary>
public class PaginationMeta
{
    /// <summary>
    /// The number of results to be returned in a page, between 1 and 200 (optional, default is 50).
    /// </summary>
    public int? Limit { get; set; }

    /// <summary>
    /// "Before" cursor for pagination.
    /// </summary>
    public string Before { get; set; }

    /// <summary>
    /// "After" cursor for pagination.
    /// </summary>
    public string After { get; set; }
}

public class ApiResponseMeta
{
    /// <summary>
    /// The identifier of the request.
    /// </summary>
    public string RequestId { get; set; }

    /// <summary>
    /// The HTTP status of the request.
    /// </summary>
    public int Status { get; set; }
}

/// <summary>
/// Duffel uses standard HTTP response codes to indicate the success or failure of API requests.
/// </summary>
public class ApiResponseError
{
    /// <summary>
    /// A machine-readable identifier for this specific error.
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// A URL pointing to a place in our documentation where you can read about the error.
    /// </summary>
    public string DocumentationUrl { get; set; }

    /// <summary>
    /// A more detailed human-readable description of what went wrong.
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// A quick and simple description of what went wrong.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// A machine-readable identifier for the general category of error.
    /// </summary>
    public string Type { get; set; }
}

public class DuffelResponse<T>
{
    /// <summary>
    /// The body of the response.
    /// </summary>
    public T Data { get; set; }

    /// <summary>
    /// Optional metadata for the request.
    /// </summary>
    public PaginationMeta Meta { get; set; }

    /// <summary>
    /// The headers from the HTTP response.
    /// </summary>
    public Dictionary<string, string> Headers { get; set; }
}

public class SDKOptions
{
    /// <summary>
    /// If true, it will output the path and the method called.
    /// </summary>
    public bool? Verbose { get; set; }
}
