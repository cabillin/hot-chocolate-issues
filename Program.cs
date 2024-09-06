using HotChocolate;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using HotChocolate.Issues.GraphQlDtos;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddMemoryCache()
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .UseAutomaticPersistedQueryPipeline()
    .AddInMemoryQueryStorage();

var app = builder.Build();

app.MapGraphQL();

app.Run();