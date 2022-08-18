using Microsoft.AspNetCore.Mvc;

namespace dotnet_core_http_logging.Controllers;

[ApiController]
[Route("[controller]")]
public class StartWarsController : ControllerBase
{
    private readonly HttpClient _httpClientFactory;

    public StartWarsController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory.CreateClient();
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var httpRequestMessage = new HttpRequestMessage
        {
            RequestUri = new Uri("https://swapi.dev/api/people/1"),
            Method = HttpMethod.Get                
        };
        
        using var result = await _httpClientFactory.SendAsync(httpRequestMessage);

        return Ok(await result.Content.ReadAsStringAsync());
    }
}