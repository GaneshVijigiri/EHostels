var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
var app = builder.Build();
app.MapReverseProxy();

app.MapDefaultEndpoints();

app.MapGet("/", () => "Hello World!");
app.Use(async (context, next) =>
{
    Console.WriteLine($"?? BFF hit: {context.Request.Method} {context.Request.Path}");
    await next();
});

app.Run();
