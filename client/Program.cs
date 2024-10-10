using client.Exercises;

namespace client;

internal class Program
{
    private const string BaseUrl = "https://localhost:7141";
    private static readonly HttpClient Client = new(){BaseAddress = new Uri(BaseUrl)};

    public static async Task Main(string[] args)
    {
        var getExercises = new GetExercises(Client);
        var postExercises = new PostExercises(Client);
        var putExercises = new PutExercises(Client);
        var deleteExercises = new DeleteExercises(Client);

        while (true)
        {
            try
            {
                Console.WriteLine("What to do?");
                var input = Console.ReadLine();
                ArgumentNullException.ThrowIfNull(input);

                switch (input.ToUpper())
                {
                    #region GET
                    case "GET":
                        await getExercises.Get(string.Empty);
                        break;
                    case "GET-S":
                        await getExercises.Get("/success");
                        break;
                    case "GET-S-P":
                        await getExercises.Get("success?id=khosro&age=30");
                        break;
                    case "GET-F":
                        await getExercises.Get("/fail");
                        break;
                    #endregion
                    case "P":
                        await postExercises.SimplePost();
                        break;
                    case "PUT":
                        putExercises.SimplePut();
                        break;
                    case "DELETE":
                        deleteExercises.SimpleDelete();
                        break;
                    case "EXIT":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        throw new NotImplementedException("This action is not implemented");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}