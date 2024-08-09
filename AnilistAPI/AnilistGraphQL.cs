using System.Net.Http.Headers;
using AnilistAPI.Objects.Object;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class AnilistGraphQL
{
    private readonly string _url = "https://graphql.anilist.co";
    private readonly HttpClient _client;

    public AnilistGraphQL()
    {
        _client = new HttpClient();
    }

    public async Task<T> PostAsync<T>(string query, object variables, string dataField)
    {
        var requestBody = new
        {
            query = query,
            variables = variables
        };

        var jsonContent = JsonConvert.SerializeObject(requestBody);
        var httpContent = new StringContent(jsonContent);
        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var response = await _client.PostAsync(_url, httpContent);
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();
        var jsonResponse = JObject.Parse(responseBody);

        var dataJson = jsonResponse["data"]?[dataField];
        if (dataJson == null)
        {
            throw new Exception("Không tìm thấy kết quả phản hồi");
        }

        return dataJson.ToObject<T>();
    }

    public Task<AniMedia> GetMediaAsync(string query, object variables)
    {
        return PostAsync<AniMedia>(query, variables, "Media");
    }

    public Task<AniCharacter> GetCharacterAsync(string query, object variables)
    {
        return PostAsync<AniCharacter>(query, variables, "Character");
    }

    public Task<AniStaff> GetStaffAsync(string query, object variables)
    {
        return PostAsync<AniStaff>(query, variables, "Staff");
    }

    public Task<AniStudio> GetStudioAsync(string query, object variables)
    {
        return PostAsync<AniStudio>(query, variables, "Studio");
    }

    public Task<AniUser> GetUserAsync(string query, object variables)
    {
        return PostAsync<AniUser>(query, variables, "User");
    }
}