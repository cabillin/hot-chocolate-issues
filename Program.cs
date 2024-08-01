using HotChocolate;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using HotChocolate.Issues.GraphQlDtos;
using HotChocolate.Issues;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddScoped<IFakeDataService, FakeDataService>()
    .AddGraphQLServer()
    .ModifyOptions(o => {
        o.EnableDefer = true;
    })
    .AddQueryType<Query>()
    .RegisterService<IFakeDataService>()
    .AddIssuesTypes();

var app = builder.Build();

app.MapGraphQL();

app.Run();