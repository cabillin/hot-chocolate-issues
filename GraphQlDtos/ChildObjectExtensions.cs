using System.Threading.Tasks;
using HotChocolate.Issues.Classes;
using HotChocolate.Types;

namespace HotChocolate.Issues.GraphQlDtos
{
    [ExtendObjectType(typeof(ChildObject))]
    public class ChildObjectExtensions
    {
        public async Task<Comment> LastComment(IFakeDataService dataService, [Parent] ChildObject parent)
        {
            return await dataService.getLatestComment(parent.Id);
        }
    }
}
