using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace AnilistAPI
{
    public class UserSearch
    {
        public static async Task SearchUser(string name)
        {
            string query = AniQuery.UserSearchQuery;
            var variables = new
            {
                name = name,
                asHtml = true
            };

            try
            {
                var apiClient = new AnilistGraphQL();
                var user = await apiClient.GetUserAsync(query, variables);

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
                throw;
            }
        }
    }
}
