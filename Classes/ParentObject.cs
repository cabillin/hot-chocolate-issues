using System.Threading.Tasks;
using OneApp.GraphQL.Server.DataLoaders;

namespace HotChocolate.Issues.Classes
{
    public class ParentObject
    {
        public int Id { get; set; }

        public string ChildId { get; set; }

    }
}
