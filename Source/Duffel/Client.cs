using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http.Headers;

public class Config
{
    public string Token { get; set; }
    public string BasePath { get; set; } = "https://api.duffel.com";
    public string ApiVersion { get; set; } = "v2";
    public bool Debug { get; set; } = false;
    public string Source { get; set; }
}

public class DuffelError : Exception
{
    public ApiResponseMeta Meta { get; }
    public List<ApiResponseError> Errors { get; }
    public HttpResponseHeaders Headers { get; }

    public DuffelError(ApiResponseMeta meta, List<ApiResponseError> errors, HttpResponseHeaders headers)
    {
        Meta = meta;
        Errors = errors;
        Headers = headers;
    }
}

public class Client
{
    private readonly string _token;
    private readonly string _basePath;
    private readonly string _apiVersion;
    private readonly bool _debug;
    private readonly string _source;
    private static readonly HttpClient _httpClient = new HttpClient();

    public Client(Config config)
    {
        _token = config.Token;
        _basePath = config.BasePath;
        _apiVersion = config.ApiVersion;
        _debug = config.Debug;
        _source = config.Source;
    }

    public async Task<DuffelResponse<T>> RequestAsync<T>(
        HttpMethod method, string path,
        Dictionary<string, object> data = null,
        Dictionary<string, object> parameters = null,
        bool compress = true)
    {
        var fullPath = new Uri(new Uri(_basePath), path);

        if (parameters != null && parameters.Any())
        {
            var query = string.Join("&", parameters
                .SelectMany(param =>
                    param.Value is IEnumerable<object> values
                        ? values.Select(value => $"{param.Key}={value}")
                        : new[] { $"{param.Key}={param.Value}" }));
            fullPath = new Uri(fullPath + "?" + query);
        }

        var userAgent = $"Duffel/{_apiVersion} duffel_api_csharp/1.0";
        if (!string.IsNullOrEmpty(_source))
        {
            userAgent += $" source/{_source}";
        }

        var request = new HttpRequestMessage(method, fullPath)
        {
            Headers =
            {
                { "User-Agent", userAgent },
                { "Accept", "application/json" },
                { "Duffel-Version", _apiVersion },
                { "Authorization", $"Bearer {_token}" }
            }
        };

        if (data != null)
        {
            var payload = JsonSerializer.Serialize(new { data });
            request.Content = new StringContent(payload, Encoding.UTF8, "application/json");
        }

        if (_debug)
        {
            Console.WriteLine($"Endpoint: {fullPath}");
            Console.WriteLine($"Method: {method}");
            if (data != null) Console.WriteLine($"Body Parameters: {JsonSerializer.Serialize(data)}");
            if (parameters != null) Console.WriteLine($"Query Parameters: {JsonSerializer.Serialize(parameters)}");
        }

        var response = await _httpClient.SendAsync(request);
        var responseContent = await response.Content.ReadAsStringAsync();

        if (_debug && response.Headers.Contains("x-request-id"))
        {
            Console.WriteLine($"Request ID: {response.Headers.GetValues("x-request-id").FirstOrDefault()}");
        }

        if (!response.IsSuccessStatusCode || responseContent.Contains("errors"))
        {
            var error = JsonSerializer.Deserialize<DuffelError>(responseContent);
            throw new DuffelError(error.Meta, error.Errors, response.Headers);
        }

        return JsonSerializer.Deserialize<DuffelResponse<T>>(responseContent);
    }

    public async IAsyncEnumerable<DuffelResponse<T>> PaginatedRequestAsync<T>(
        string path, Dictionary<string, object> parameters = null)
    {
        var response = await RequestAsync<List<T>>(HttpMethod.Get, path, parameters);
        foreach (var item in response.Data)
        {
            yield return new DuffelResponse<T> { Data = item };
        }

        while (response.Meta != null && !string.IsNullOrEmpty(response.Meta.After))
        {
            response = await RequestAsync<List<T>>(HttpMethod.Get, path, parameters: new Dictionary<string, object>
            {
                { "limit", response.Meta.Limit },
                { "after", response.Meta.After }
            });

            foreach (var item in response.Data)
            {
                yield return new DuffelResponse<T> { Data = item };
            }
        }
    }
}
