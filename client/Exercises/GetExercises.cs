using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using client.Utilities;

// ReSharper disable ReplaceWithPrimaryConstructorParameter

namespace client.Exercises;

internal sealed class GetExercises(HttpClient client)
{
    private readonly HttpClient _client = client;
    private readonly JsonSerializerOptions _jsonSerializerOptions = new(){WriteIndented = true};

    public async Task Get(string path)
    {
        Print.Info($"Making a GET request to {_client.BaseAddress}{path}");
        var responseMessage = await _client.GetAsync(path);

        try
        {
            responseMessage.EnsureSuccessStatusCode();
            var content = await responseMessage.Content.ReadAsStringAsync();
            var jsonNode = JsonNode.Parse(content);
            var jsonElement = JsonSerializer.Deserialize<JsonElement>(content);
            var prettyJson = JsonSerializer.Serialize(jsonElement, _jsonSerializerOptions);
            Print.Success(prettyJson);
            Print.Success($"ID: {jsonNode?.Root["id"]!}");
            Print.Success($"Age: {jsonNode?.Root["age"]!}");
            Print.Success($"Status code: {(int)responseMessage.StatusCode}");
        }
        catch (HttpRequestException e)
        {
            Print.Error(e.Message);
            Print.Error($"Status code: {(int)responseMessage.StatusCode}");
        }
        catch (ArgumentNullException e)
        {
            Print.Error(e.Message);
            Print.Error($"Status code: {(int)responseMessage.StatusCode}");
        }
        catch (Exception e)
        {
            Print.Error($"An unhandled exception was thrown: {e.Message}");
            Print.Error($"Status code: {(int)responseMessage.StatusCode}");
        }
    }
}