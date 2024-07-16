
using GreenDonut;
using HotChocolate.Issues;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace OneApp.GraphQL.Server.DataLoaders
{
    public class ChildByIdDataLoader : BatchDataLoader<string, ChildObject>
    {
        public ChildByIdDataLoader(
            IBatchScheduler batchScheduler,
            DataLoaderOptions? options = null)
            : base(batchScheduler, options)
        {
        }

        protected override async Task<IReadOnlyDictionary<string, ChildObject>> LoadBatchAsync(IReadOnlyList<string> childIds, CancellationToken cancellationToken)
        {
            await Task.Delay(5000);
            var children = childIds.ToDictionary(x=>x, x=> new ChildObject() { Id=x });
            IReadOnlyDictionary<string, ChildObject> readOnlyChildren = children;
            return readOnlyChildren;
        }
    }
}
