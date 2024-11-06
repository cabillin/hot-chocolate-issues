using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate.Issues.Classes;

namespace HotChocolate.Issues
{
    public interface IFakeDataService
    {
        public Task<List<ParentObject>> GetAllParents();

        public Task<IDictionary<string, ChildObject>> GetChildrenByIds(List<string> childIds);
        public Task<Comment> getLatestComment(string id);
    }
}