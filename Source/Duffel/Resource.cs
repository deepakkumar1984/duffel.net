using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Resource
{
    private readonly Client _client;

    public Resource(Client client)
    {
        _client = client;
    }

    protected async Task<DuffelResponse<T>> RequestAsync<T>(
        HttpMethod method,
        string path,
        Dictionary<string, object> data = null,
        Dictionary<string, object> parameters = null)
    {
        return await _client.RequestAsync<T>(method, path, data, parameters);
    }

    protected async IAsyncEnumerable<DuffelResponse<T>> PaginatedRequestAsync<T>(
        string path,
        Dictionary<string, object> parameters = null)
    {
        await foreach (var response in _client.PaginatedRequestAsync<T>(path, parameters))
        {
            yield return response;
        }
    }
}
