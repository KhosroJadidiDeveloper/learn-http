namespace client.Exercises;

internal sealed  class GetExercises
{
    private readonly HttpClient _client;

    public GetExercises(HttpClient client)
    {
        _client = client;
    }

    public void SimpleGet()
    {
        throw new NotImplementedException();
    }
}