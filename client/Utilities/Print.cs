namespace client.Utilities;

internal static class Print
{
    internal static void Info(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        InternalPrint(message);
    }
    internal static void Success(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        InternalPrint(message);
    }

    internal static void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        InternalPrint(message);
    }

    private static void InternalPrint(string message)
    {
        Console.WriteLine(message);
        Console.ResetColor();
    }
}