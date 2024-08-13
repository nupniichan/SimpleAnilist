using AnilistAPI;

class Program
{
    static async Task Main(string[] args)
    {
        // Example code
        var client = new AnilistGraphQL();
        try
        {
            var anime = await client.GetMediaAsync(AniQuery.AnimeNameQuery, new { search = "Is the order rabbit? Bloom", asHtml = true });

            Console.WriteLine($"ID: {anime.id}");
            Console.WriteLine($"Title: {anime.title.romaji}");
            Console.WriteLine($"Description: {anime.description}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}