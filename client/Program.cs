
using client.Exercises;

namespace client;

internal class Program
{
    private static readonly HttpClient Client = new ();
    public static void Main(string[] args)
    {
        var getExercises = new GetExercises(Client);
        var postExercises = new PostExercises(Client);
        var putExercises = new PutExercises(Client);
        var deleteExercises = new DeleteExercises(Client);

        while (true)
        {
            Console.WriteLine("What to do?");
            var input = Console.ReadLine();
            ArgumentNullException.ThrowIfNull(input);

            switch (input.ToUpper())
            {
                case "GET":
                    getExercises.SimpleGet();
                    break;
                case "POST":
                    postExercises.SimplePost();
                    break;
                case "PUT":
                    putExercises.SimplePut();
                    break;
                case "DELETE":
                    deleteExercises.SimpleDelete();
                    break;
                default:
                    throw new NotImplementedException("This action is not implemented");
            }
        }

    }
}