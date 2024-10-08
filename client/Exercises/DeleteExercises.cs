namespace client.Exercises;

internal sealed class DeleteExercises
{
    private readonly HttpClient _client;
    private readonly string _baseUrl;

    public DeleteExercises(HttpClient client)
    {
        _client = client;
    }

    public void SimpleDelete()
    {
        throw new NotImplementedException();
    }
}