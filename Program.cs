using Platform;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("example/red{color}", async context =>
{
  await context.Response.WriteAsync("Request Was Routed\n");
  foreach (var kvp in context.Request.RouteValues)
  {
    await context.Response
    .WriteAsync($"{kvp.Key}: {kvp.Value}\n");
  }
});
app.MapGet("capital/{country}", Capital.Endpoint);
app.MapGet("size/{city}", Population.Endpoint)
  .WithMetadata(new RouteNameMetadata("population")); // Route is named population.

app.Run();
