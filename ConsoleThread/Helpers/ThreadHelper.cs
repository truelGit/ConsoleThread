namespace ConsoleThread.Helpers;

public class ThreadHelper
{
    private static int _x = 0;
    
    public void Start()
    {
        for (var i = 1; i < 6; i++)
        {
            var thread = new Thread(Count)
            {
                Name = $"Thread {i}"
            };
            thread.Start();
        }
    }
    
    private static void Count()
    {
        _x = 1;
        for (var i = 1; i < 6; i++)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name}: {_x}");
            _x++;
            Thread.Sleep(100);
        }
    }
}