namespace ConsoleThread;

internal static class Program
{
    private static int _x = 0;
    private static object _locker = new object();
    private static void Main()
    {
        for (var i = 1; i < 6; i++)
        {
            var thread = new Thread(CountWithMonitor)
            {
                Name = $"Thread {i}"
            };
            thread.Start();
        }

        Console.ReadKey();
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
    
    private static void CountWithLock()
    {
        lock(_locker)
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

    private static void CountWithMonitor()
    {
        bool acquiredLock = false;
        try
        {
            Monitor.Enter(_locker, ref acquiredLock);
            _x = 1;
            for (var i = 1; i < 6; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {_x}");
                _x++;
                Thread.Sleep(100);
            }
        }
        finally
        {
            if(acquiredLock) Monitor.Exit(_locker);
        }
    }
}