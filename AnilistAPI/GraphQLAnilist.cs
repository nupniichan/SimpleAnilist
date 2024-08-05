using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AnilistAPI.Objects.Object; // Cập nhật namespace của bạn nếu cần

public class GraphQLAnilist
{
    private readonly string _url = "https://graphql.anilist.co";
    private readonly HttpClient _client;

    public GraphQLAnilist()
    {
        _client = new HttpClient();
    }

    public async Task<Media> MediaPostAsync(string query, object variables)
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

        var mediaJson = jsonResponse["data"]?["Media"];
        if (mediaJson == null)
        {
            throw new Exception("Không tìm thấy kết quả phản hồi");
        }

        return mediaJson.ToObject<Media>();
    }
    public async Task<Character> CharacterPostAsync(string query, object variables)
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

        var mediaJson = jsonResponse["data"]?["Character"];
        if (mediaJson == null)
        {
            throw new Exception("Không tìm thấy kết quả phản hồi");
        }

        return mediaJson.ToObject<Character>();
    }
    public async Task<Staff> StaffPostAsync(string query, object variables)
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

        var mediaJson = jsonResponse["data"]?["Staff"];
        if (mediaJson == null)
        {
            throw new Exception("Không tìm thấy kết quả phản hồi");
        }

        return mediaJson.ToObject<Staff>();
    }
    public async Task<Studio> StudioPostAsync(string query, object variables)
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

        var mediaJson = jsonResponse["data"]?["Studio"];
        if (mediaJson == null)
        {
            throw new Exception("Không tìm thấy kết quả phản hồi");
        }

        return mediaJson.ToObject<Studio>();
    }
    public async Task<User> UserPostAsync(string query, object variables)
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

        var mediaJson = jsonResponse["data"]?["User"];
        if (mediaJson == null)
        {
            throw new Exception("Không tìm thấy kết quả phản hồi");
        }

        return mediaJson.ToObject<User>();
    }
}
