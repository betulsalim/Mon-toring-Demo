using Serilog;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

// Serilog yapýlandýrmasý
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

// Prometheus metrikleri middleware olarak eklenir
builder.Services.AddControllers();

var app = builder.Build();

// Prometheus endpoint: /metrics
app.UseHttpMetrics();
app.MapMetrics();

app.UseAuthorization();
app.MapControllers();

app.Run();
