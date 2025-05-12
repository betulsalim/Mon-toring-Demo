using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prometheus;

namespace MonitoringDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;
    private static readonly Counter LoginCounter = Metrics.CreateCounter("login_count", "Login denemesi sayýsý");

    public TestController(ILogger<TestController> logger)
    {
        _logger = logger;
    }

    [HttpGet("login")]
    public IActionResult Login()
    {
        _logger.LogInformation("Login endpoint'e eriþildi.");
        LoginCounter.Inc(); // Telemetri metrik artýrýlýyor
        return Ok("Giriþ baþarýlý");
    }
}
