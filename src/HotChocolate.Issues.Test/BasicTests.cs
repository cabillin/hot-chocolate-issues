// -----------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Microsoft.Extensions.DependencyInjection;
using HotChocolate;
using HotChocolate.Execution;
using Snapshooter.Xunit;
using HotChocolate.Issues.GraphQlDtos;

namespace GraphQL.Server.Test
{
    public class BasicTests
    {
        /// <summary>
        /// If this test failed, then it means you changed the schema
        /// If you intended to change the schema, then validate the changes in the mismatch folder then replace the checked in snapshot
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task SchemaChangeTest()
        {
            var schema = await new ServiceCollection()
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .BuildSchemaAsync();

            schema.ToString().MatchSnapshot();
        }
    }
}
