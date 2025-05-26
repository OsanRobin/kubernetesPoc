var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.kubernetesPoc_ApiService>("apiservice");

builder.AddProject<Projects.kubernetesPoc_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
