## Simple Anilist 

This is a simple C# library for interacting with the Anilist API (it just take some basic information). As it's not yet published on NuGet, you'll need to include the project in your solution to use it. But i will publish to nuget soon so please stand by...

### Setup

1. **Download the source code:**
   - Clone this repository or download the source code as a ZIP file and extract it.
2. **Include the project in your solution:**
   - Open your C# solution in Visual Studio.
   - Right-click on your solution in the Solution Explorer and select "Add" -> "Existing Project...".
   - Navigate to the directory where you extracted the source code and select the AnilistAPI project file (`.csproj`).
3. **Add a reference to your project:**
   - In your project, right-click on "References" in the Solution Explorer and select "Add Reference...".
   - Select the "Projects" tab and check the box next to the AnilistAPI project.
   - Click "OK" to add the reference.

### Usage

Now that you have included the project, you can start using the Anilist API Client. 

**1. Initialize AnilistGraphQL:**

```C#
using AnilistAPI;

var client = new AnilistGraphQL();
```

**2. Make Queries:**

```C#
// Get anime by ID 
var anime = await client.GetMediaAsync(AniQuery.AnimeIDQuery, new { id = "104198", asHtml = true });

// Get anime by name 
var anime = await client.GetMediaAsync(AniQuery.AnimeNameQuery, new { search = "Is the order rabbit? Bloom", asHtml = true });

// Get manga by id
var manga = await client.GetMediaAsync(AniQuery.MangaIDQuery, new { id = 79835 , asHtml = true });

// Get manga by name
var manga = await client.GetMediaAsync(AniQuery.MangaNameQuery, new { search = "Is the order rabbit?" , asHtml = true });

// Get character by name
var character = await client.GetCharacterAsync(AniQuery.CharacterSearchQuery, new { search = "Chino Kafuu", asHtml = true });

// Get staff by name
var staff = await client.GetStaffAsync(AniQuery.StaffSearchQuery, new { search = "Koi" , asHtml = true });

// Get studio by name
var studio = await client.GetStudioAsync(AniQuery.StudioSearchQuery, new { search = "Encourage Films", asHtml = true });

// Get user by name
var user = await client.GetUserAsync(AniQuery.UserSearchQuery, new { name = "nupniichan", asHtml = true });
```

**3. Access Data:**

You can access the returned data through the properties of the respective objects like:

```C#
    public class AniCharacter
    {
        public CharacterName name { get; set; }
        public string description { get; set; }
        public CharacterImage image { get; set; }
        public CharacterDateOfBirth dateOfBirth { get; set; }
        public string gender { get; set; }
        public string siteUrl { get; set; }
    }

    public class AniMedia
    {
        public int id { get; set; }
        public int idMal { get; set; }
        public Title title { get; set; }
        public string type { get; set; }
        public string format { get; set; }
        public MediaStatus status { get; set; }
        public string description { get; set; }
        public StartDate startDate { get; set; }
        public EndDate endDate { get; set; }
        public int? episodes { get; set; }
        public int? chapters { get; set; }
        public int? volumes { get; set; }
        public CoverImage coverImage { get; set; }
        public string bannerImage { get; set; }
        public int? averageScore { get; set; }
        public int? meanScore { get; set; }
        public string season { get; set; }
        public List<string> genres { get; set; }
        public string source { get; set; }
        public string siteUrl { get; set; }
        public int? duration { get; set; }
        public AiringSchedule airingSchedule { get; set; }
    }

    public class AniStaff
    {
        public StaffName name { get; set; }
        public string languageV2 { get; set; }
        public StaffImage image { get; set; }
        public string description { get; set; }
        public string siteUrl { get; set; }
        public List<string> primaryOccupations { get; set; }
        public string gender { get; set; }
        public string homeTown { get; set; }
    }

    public class AniStudio
    {
        public string name { get; set; }
        public string siteUrl { get; set; }
    }

    public class AniUser
    {
        public int id { get; set; }
        public string name { get; set; }
        public UserAvatar avatar { get; set; }
        public string bannerImage { get; set; }
        public string about { get; set; }
        public UserFavourites favourites { get; set; }
        public UserStatistics statistics { get; set; }
        public string siteUrl { get; set; }
    }
```

### GraphQL Queries

Pre-defined GraphQL queries are located in the `Query` class:

```C#
public static class Query
{
    public const string AnimeIDQuery = @"...";
    public const string MangaNameQuery = @"...";
}
```

### Notes

* Make sure to replace placeholders like `id`, `search`, `name` with actual values.
* Refer to the Anilist API documentation for more details about available queries and data: https://anilist.gitbook.io/anilist-apiv2-docs/ and https://anilist.co/graphiql

### Example

```C#
using AnilistAPI;

class Program
{
    static async Task Main(string[] args)
    {
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
```

### Contributing

Contributions and feedback are always welcome! 
