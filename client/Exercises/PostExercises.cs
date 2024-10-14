using System.Diagnostics.CodeAnalysis;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using client.Dto;
using client.Utilities;

namespace client.Exercises;

[SuppressMessage("ReSharper", "ReplaceWithPrimaryConstructorParameter")]
internal sealed class PostExercises(HttpClient client)
{
    private readonly HttpClient _client = client;

    public async Task Post()
    {
        try
        {
            var postContect = new UserDto
            {
                Id = null,
                Age = 35,
                Name = "Dude"
            };
            var stringContent = new StringContent(JsonSerializer.Serialize(postContect), Encoding.UTF8,
                MediaTypeNames.Application.Json);
            var postResponse = await _client.PostAsync("/success", stringContent);
            postResponse.EnsureSuccessStatusCode();
            var postContent = await postResponse.Content.ReadAsStringAsync();
            Print.Success(postContent);
        }
        catch (Exception e)
        {
            Print.Error($"An unhandled exception was thrown: {e.Message}");
        }
    }
}