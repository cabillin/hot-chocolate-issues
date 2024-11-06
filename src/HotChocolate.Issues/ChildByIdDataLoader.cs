
using GreenDonut;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using HotChocolate.Issues.Classes;
using HotChocolate.Issues;

namespace OneApp.GraphQL.Server.DataLoaders
{
    public class ChildByIdDataLoader : BatchDataLoader<string, ChildObject>
    {
        private IFakeDataService dataService;

        public ChildByIdDataLoader(
            IBatchScheduler batchScheduler,
            IFakeDataService dataService,
            DataLoaderOptions? options = null)
            : base(batchScheduler, options)
        {
            this.dataService = dataService;
        }

        protected override async Task<IReadOnlyDictionary<string, ChildObject>> LoadBatchAsync(IReadOnlyList<string> childIds, CancellationToken cancellationToken)
        {
            var children = await dataService.GetChildrenByIds((List<string>)childIds);
            return (IReadOnlyDictionary<string, ChildObject>) children;
        }
    }
}
