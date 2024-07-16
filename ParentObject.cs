using System.Threading.Tasks;
using OneApp.GraphQL.Server.DataLoaders;

namespace HotChocolate.Issues
{
    public class ParentObject
    {
        public int Id { get; set; }

        public string ChildId { get; set; }

        public async Task<ChildObject> Child(ChildByIdDataLoader childDataLoader, [Parent] ParentObject parent)
        {
            return await childDataLoader.LoadAsync(parent.ChildId);
        }
    }
}
