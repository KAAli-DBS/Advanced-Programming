using System;

class Program
{
    // Declare an event using EventHandler
    public static event EventHandler OnNotify;

    static void Main()
    {
        // Subscribe to the event using a simple lambda
        OnNotify += (sender, e) => Console.WriteLine("Subscriber: Event received!");

        // Trigger the event
        Console.WriteLine("Publisher: Raising the event...");
        OnNotify?.Invoke(null, EventArgs.Empty);
    }
}
