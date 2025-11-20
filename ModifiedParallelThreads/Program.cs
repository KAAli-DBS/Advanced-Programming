// Modify the Parallel Thread code to pause the main thread for 2 seconds after printing the first 2 numbers without affecting the worker thread. 


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

            // Pause for 2 seconds after printing the first 2 numbers (i = 0 and i = 1)
            if (i == 1)
            {
                Thread.Sleep(2000);   // Pause main thread for 2 seconds
            }
            else
            {
                Thread.Sleep(500);    // Normal 0.5 second sleep for other iterations
            }
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

