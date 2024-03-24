using Infrastructure.Contracts;
using Newtonsoft.Json;

namespace Infrastructure.Services;

internal class HttpService : IHttpService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HttpService(IHttpClientFactory httpClientFactory)
    {
        ArgumentNullException.ThrowIfNull(httpClientFactory);
        
        _httpClientFactory = httpClientFactory;
    }

    public async Task<T?> Get<T>(string url) where T : class
    {
        using var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var responseBody = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(responseBody);
    }
}