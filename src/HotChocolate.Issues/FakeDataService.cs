using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Issues.Classes;

namespace HotChocolate.Issues
{
    public class FakeDataService : IFakeDataService
    {
        public async Task<List<ParentObject>> GetAllParents()
        {
            await Task.Delay(5000);
            return new List<ParentObject> {
                new ParentObject { Id = 1, ChildId = "Child1", Flags = FlagEnum.None },
                new ParentObject { Id = 2, ChildId = "Child2", Flags = FlagEnum.BOB },
                new ParentObject { Id = 3, ChildId = "Child2" , Flags = FlagEnum.ANA},
                new ParentObject { Id = 4, ChildId = "Child2" , Flags = FlagEnum.CLAIRE},
                new ParentObject { Id = 5, ChildId = "Child5", Flags = FlagEnum.All },
                new ParentObject { Id = 6, ChildId = "Child2" , Flags = FlagEnum.BOB|FlagEnum.ANA},
                new ParentObject { Id = 7, ChildId = "Child1", Flags = FlagEnum.None },
                new ParentObject { Id = 8, ChildId = "Child3" , Flags = FlagEnum.ANA|FlagEnum.CLAIRE},
                new ParentObject { Id = 9, ChildId = "Child4" , Flags = FlagEnum.None},
                new ParentObject { Id = 10, ChildId = "Child2"  , Flags = FlagEnum.None},
                new ParentObject { Id = 11, ChildId = "Child1" , Flags = FlagEnum.BOB|FlagEnum.ANA|FlagEnum.CLAIRE}
            };
        }

        public async Task<IDictionary<string, ChildObject>> GetChildrenByIds(List<string> childIds)
        {
            await Task.Delay(4000);
            var children = childIds.ToDictionary(x => x, x => new ChildObject() { Id = x });
            return children;
        }

        public async Task<Comment> getLatestComment(string id)
        {
            await Task.Delay(2000);
            return new Comment()
            {
                Id = "comment_" + id + 1,
                Contents = "hello world"
            };
        }
    }
}
