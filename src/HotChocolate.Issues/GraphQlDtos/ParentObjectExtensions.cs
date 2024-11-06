using System.Threading.Tasks;
using HotChocolate.Issues.Classes;
using HotChocolate.Types;
using OneApp.GraphQL.Server.DataLoaders;

namespace HotChocolate.Issues.GraphQlDtos
{
    [ExtendObjectType(typeof(ParentObject))]
    public class ParentObjectExtensions
    {
        public async Task<ChildObject> Child(ChildByIdDataLoader childDataLoader, [Parent] ParentObject parent)
        {
            return await childDataLoader.LoadAsync(parent.ChildId);
        }
    }
}
