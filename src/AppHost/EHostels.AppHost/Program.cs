var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.EHostels_API>("api");

var bff = builder.AddProject<Projects.EHostels_BFF>("bff")
    .WithReference(api);
builder.AddNpmApp("ui", "../../Frontend/ehostels.ui","dev")
    .WithReference(bff);

builder.Build().Run();
