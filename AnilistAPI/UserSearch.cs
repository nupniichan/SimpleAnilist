using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnilistAPI
{
    public class UserSearch
    {
        public static async Task SearchUser(string name)
        {
            string query = Query.UserSearchQuery;
            var variables = new
            {
                name = name,
                asHtml = true
            };

            try
            {
                var apiClient = new GraphQLAnilist();
                var user = await apiClient.UserPostAsync(query, variables);

                await Console.Out.WriteLineAsync(user.name);
                await Console.Out.WriteLineAsync(user.about);
                Console.WriteLine("Anime Favourites:");
                if (user.favourites.anime != null)
                {
                    foreach (var anime in user.favourites.anime.nodes)
                    {
                        var title = anime.title.romaji ?? "No title";
                        var url = anime.siteUrl ?? "No URL";
                        Console.WriteLine($"- {title} ({url})");
                    }
                }
                else
                {
                    Console.WriteLine("No anime favourites found.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi: " + e.Message);
                Console.WriteLine(e.ToString());
            }
        }
    }
}
