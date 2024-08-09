using AnilistAPI.AnilistAPI.Enum;

namespace AnilistAPI
{
    public class MediaSearch
    {
        public static async Task SearchMediaID(int id, AniMediaType mediaType)
        {
            string query = "";
            if (mediaType == AniMediaType.ANIME)
            {
                query = Query.AnimeIDQuery;
            }
            else
            {
                query = Query.MangaIDQuery;
            }
            var variables = new
            {
                id = id,
                type = Enum.GetName(typeof(AniMediaType), mediaType),
                asHtml = true
            };

            try
            {
                var apiClient = new GraphQLAnilist();
                var media = await apiClient.GetMediaAsync(query, variables);

                Console.WriteLine($"ID: {media.id}");
                Console.WriteLine($"Title (Romaji): {media.title.romaji}");
                Console.WriteLine($"Title (English): {media.title.english}");
                Console.WriteLine($"Title (Native): {media.title.native}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi: " + e.Message);
                Console.WriteLine(e.ToString());
                throw;
            }
        }
        public static async Task SearchMediaName(string name, AniMediaType mediaType)
        {
            string query = "";
            if (mediaType == AniMediaType.ANIME)
            {
                query = Query.AnimeNameQuery;
            }
            else
            {
                query = Query.MangaNameQuery;
            }
            var variables = new
            {
                search = name,
                type = Enum.GetName(typeof(AniMediaType), mediaType),
                asHtml = true
            };

            try
            {
                var apiClient = new GraphQLAnilist();
                var media = await apiClient.GetMediaAsync(query, variables);

                Console.WriteLine($"ID: {media.id}");
                Console.WriteLine($"Title (Romaji): {media.title.romaji}");
                Console.WriteLine("Description: " + media.description);
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
