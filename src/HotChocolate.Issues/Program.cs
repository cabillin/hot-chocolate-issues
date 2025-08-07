using System;
using HotChocolate;
using HotChocolate.Issues;
using HotChocolate.Issues.GraphQlDtos;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddScoped<IFakeDataService, FakeDataService>()
    .AddGraphQLServer()
    .InitializeOnStartup() // By default the creation of Hot Chocolate's schema is lazy; we want the schema creation process to happen at server startup
    .ModifyOptions(o =>
    {
        o.EnableDefer = true;
        o.EnableFlagEnums = true;
    })
    .DisableIntrospection(true)
    // Batching is disabled per default
    .ModifyRequestOptions(o =>
    {
        // default timeout is 30 seconds (will abort execution of request)
        // executionTimeout is not honored if a debugger is attached
        o.ExecutionTimeout = TimeSpan.FromSeconds(240);
        // Per default HotChocolate does not expose the details of your exceptions, if no debugger is attached
        o.IncludeExceptionDetails = true;
    })
    .ModifyCostOptions(o =>
    {
        // https://chillicream.com/docs/hotchocolate/v14/security/cost-analysis#accessing-cost-metrics
        o.EnforceCostLimits = true;
        o.ApplyCostDefaults = true;
    })
    // default number of validation errors is 5
    // As soon as the execution engine tries to produce a 6th validation error, the validation process is aborted and the previous 5 errors are returned.
    //.SetMaxAllowedValidationErrors(5)
    .ModifyPagingOptions(o =>
    {
        o.AllowBackwardPagination = false;
        o.RequirePagingBoundaries = true;
        // no DefaultPageSize because page size must always be provided per RequirePagingBoundaries
    })
    .AddQueryType<Query>()
    .UseDefaultPipeline()
    //.AddIssuesTypes()
    .AddFiltering()
    .AddPagingArguments()//inject PagingArguments as arguments to Query entrypoints
    .AddQueryContext();

var app = builder.Build();

app.MapGraphQL();

app.Run();