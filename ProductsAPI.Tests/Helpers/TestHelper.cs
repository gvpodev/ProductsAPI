using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Text;


namespace ProductsAPI.Tests.Helpers;

public static class TestHelper
{
    public static HttpClient CreateClient
        => new WebApplicationFactory<Program>().CreateClient();
    
    public static StringContent CreateContent<TRequest>
        (TRequest request)
        => new StringContent
        (JsonConvert.SerializeObject(request),
            Encoding.UTF8, "application/json");
    
    public static TResponse? ReadResponse<TResponse>
        (HttpResponseMessage message)
        => JsonConvert.DeserializeObject<TResponse>
            (message.Content.ReadAsStringAsync().Result);
}
