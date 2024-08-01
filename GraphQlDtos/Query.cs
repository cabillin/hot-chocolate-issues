using HotChocolate.Issues.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotChocolate.Issues.GraphQlDtos
{
    public class Query
    {
        public async Task<List<ParentObject>> GetParents(IFakeDataService dataService)
        {
            return await dataService.GetAllParents();
        }
    }
}
