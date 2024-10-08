namespace client.Exercises;

internal sealed class PostExercises
{
    private readonly HttpClient _client;
    private readonly string _baseUrl;

    public PostExercises(HttpClient client)
    {
        _client = client;
    }

    public void SimplePost()
    {
        throw new NotImplementedException();
    }
}