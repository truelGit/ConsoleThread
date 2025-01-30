using ConsoleThread.Helpers;

namespace ConsoleThread;


internal static class Program
{
    private static void Main()
    {
        var threadHelper = new ThreadHelper();
        threadHelper.Start();

        Console.ReadKey();
    }
}