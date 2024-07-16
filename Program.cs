using HotChocolate;
using HotChocolate.Issues;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .ModifyOptions(o => {
        o.EnableDefer = true;
    })
    .AddQueryType<Query>()
    .AddIssuesTypes();

var app = builder.Build();

app.MapGraphQL();

app.Run();

public class Query
{

    public async Task<List<ParentObject>> GetParents()
    {
        await Task.Delay(5000);
        return new List<ParentObject> {
            new ParentObject { Id = 1, ChildId = "Child1" },
            new ParentObject { Id = 2, ChildId = "Child2" },
            new ParentObject { Id = 3, ChildId = "Child2" },
            new ParentObject { Id = 4, ChildId = "Child2" },
            new ParentObject { Id = 5, ChildId = "Child5" },
            new ParentObject { Id = 6, ChildId = "Child2" },
            new ParentObject { Id = 7, ChildId = "Child1" },
            new ParentObject { Id = 8, ChildId = "Child3" },
            new ParentObject { Id = 9, ChildId = "Child4" },
            new ParentObject { Id = 10, ChildId = "Child2" },
            new ParentObject { Id = 11, ChildId = "Child1" }

        };
    }
}
