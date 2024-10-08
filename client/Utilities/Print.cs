namespace client.Utilities;

internal static class Print
{
    internal static void Info(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    internal static void Success(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    internal static void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}