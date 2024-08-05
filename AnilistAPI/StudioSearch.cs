using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnilistAPI
{
    public class StudioSearch
    {
        public static async Task SearchStudio(string name)
        {
            string query = Query.StudioSearchQuery;
            var variables = new
            {
                search = name
            };

            try
            {
                var apiClient = new GraphQLAnilist();
                var staff = await apiClient.StudioPostAsync(query, variables);

                await Console.Out.WriteLineAsync(staff.name);
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi: " + e.Message);
                Console.WriteLine(e.ToString());
            }
        }
    }
}
