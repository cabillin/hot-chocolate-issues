using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GreenDonut.Data;
using HotChocolate.Data;
using HotChocolate.Issues.Classes;
using HotChocolate.Resolvers;
using HotChocolate.Types;

namespace HotChocolate.Issues.GraphQlDtos
{
    public class Query
    {
        public string Ping()
        {
            return "Hello World";
        }

        [UsePaging, UseFiltering]            
        public async Task<List<ParentObject>> GetParents(
            //injected 
            CancellationToken cancellationToken,
            IResolverContext context, 
            [Service] IFakeDataService dataService,
            // "magic" inputs
            PagingArguments pagingArgs,
            QueryContext<ParentObject> queryContext)
        {
            return await dataService.GetAllParents();
        }
    }
}
