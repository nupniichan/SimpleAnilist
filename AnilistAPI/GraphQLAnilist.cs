using System.Net.Http.Headers;
using AnilistAPI.Objects.Object;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class GraphQLAnilist
{
    private readonly string _url = "https://graphql.anilist.co";
    private readonly HttpClient _client;

    public GraphQLAnilist()
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

    public Task<Media> GetMediaAsync(string query, object variables)
    {
        return PostAsync<Media>(query, variables, "Media");
    }

    public Task<Character> GetCharacterAsync(string query, object variables)
    {
        return PostAsync<Character>(query, variables, "Character");
    }

    public Task<Staff> GetStaffAsync(string query, object variables)
    {
        return PostAsync<Staff>(query, variables, "Staff");
    }

    public Task<Studio> GetStudioAsync(string query, object variables)
    {
        return PostAsync<Studio>(query, variables, "Studio");
    }

    public Task<User> GetUserAsync(string query, object variables)
    {
        return PostAsync<User>(query, variables, "User");
    }
}