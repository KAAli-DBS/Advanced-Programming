using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Thread thread = new Thread(PrintNumbers);
        thread.Start();
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Main thread: {i}");
            Thread.Sleep(500); 
        }
        thread.Join();
        Console.WriteLine("Both threads are complete.");
    }

    static void PrintNumbers()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Worker thread: {i}");
            Thread.Sleep(500); 
        }
    }
}