using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotChocolate.Execution;
using HotChocolate.Issues.GraphQlDtos;
using Microsoft.Extensions.DependencyInjection;

namespace HotChocolate.Issues.Test
{
    public static class TestServices
    {

        static TestServices() {
            ServiceProvider = new ServiceCollection()
                    .AddGraphQLServer()
                    .AddQueryType<Query>()
                    .Services
                    .AddSingleton(sp => new RequestExecutorProxy(sp.GetRequiredService<IRequestExecutorResolver>(),
                    Schema.DefaultName))
                    .BuildServiceProvider();

            RequestExecutorProxy = ServiceProvider.GetRequiredService<RequestExecutorProxy>();
        }

        public static IServiceProvider ServiceProvider { get; }

        public static RequestExecutorProxy RequestExecutorProxy { get; }

        public static async Task<string> ExecuteRequestAsync(Action<IQueryRequestBuilder> configureRequest,
        CancellationToken cancellationToken = default)
        {
            await using var scope = ServiceProvider.CreateAsyncScope();

            var requestBuilder = new QueryRequestBuilder();
            requestBuilder.SetServices(scope.ServiceProvider);
            configureRequest(requestBuilder);
            var request = requestBuilder.Create();

            await using var result = await RequestExecutorProxy.ExecuteAsync(request, cancellationToken);

            result.ExpectQueryResult();//no defer support

            return result.ToJson();
        }
    }
}
