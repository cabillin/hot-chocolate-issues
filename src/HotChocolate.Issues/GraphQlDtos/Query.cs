using HotChocolate.Data;
using HotChocolate.Issues.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotChocolate.Issues.GraphQlDtos
{
    public class Query
    {
        public string Ping()
        {
            return "Hello World";
        }

        [UseFiltering]
        public async Task<List<ParentObject>> GetParents([Service]IFakeDataService dataService)
        {
            return await dataService.GetAllParents();
        }
    }
}
