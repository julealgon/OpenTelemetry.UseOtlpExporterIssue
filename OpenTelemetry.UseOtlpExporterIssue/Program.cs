using Microsoft.Extensions.Options;
using OpenTelemetry;
using OpenTelemetry.Exporter;

var builder = Host.CreateEmptyApplicationBuilder(settings: null);

builder.Configuration.AddEnvironmentVariables("MyCustomPrefix_");

builder.Services.AddOpenTelemetry().UseOtlpExporter();

var host = builder.Build();

var options = host.Services.GetRequiredService<IOptions<OtlpExporterOptions>>();

Console.WriteLine($"Endpoint: {options.Value.Endpoint}");
