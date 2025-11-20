// To find-out about how many cores and logical cores your GitHub has: 

// Console.WriteLine("Cores count: " + Environment.ProcessorCount);

using System;
using System.Threading;

class Program
{
    static void Main()
    {
        // Create and start a thread
        Thread thread = new Thread(() => Console.WriteLine("Hello from the new thread!"));
        thread.Start();

        // Main thread continues
        Console.WriteLine("Hello from the main thread!");

        // Wait for the thread to finish
        thread.Join();
    }
}

