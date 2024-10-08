using System.Text.Json;
using client.Utilities;

// ReSharper disable ReplaceWithPrimaryConstructorParameter

namespace client.Exercises;

internal sealed class GetExercises(HttpClient client)
{
    private readonly HttpClient _client = client;

    public async Task Get(string path)
    {
        Print.Info($"Making a GET request to {_client.BaseAddress}{path}");
        var responseMessage = await _client.GetAsync(path);

        try
        {
            responseMessage.EnsureSuccessStatusCode();
            var content = await responseMessage.Content.ReadAsStringAsync();
            Print.Success(content);
            Print.Success($"Status code: {(int)responseMessage.StatusCode}");
        }
        catch (HttpRequestException e)
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