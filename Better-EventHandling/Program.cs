using System;

// Publisher class
class Publisher
{
    // Declare an event
    public event EventHandler OnChange;

    // Method to trigger the event
    public void RaiseEvent()
    {
        Console.WriteLine("Publisher: Something happened!");
        OnChange?.Invoke(this, EventArgs.Empty);
    }
}

// Subscriber class
class Subscriber
{
    public void Subscribe(Publisher pub)
    {
        pub.OnChange += HandleEvent;
    }

    private void HandleEvent(object sender, EventArgs e)
    {
        Console.WriteLine("Subscriber: I got notified!");
    }
}

// Main program
class Program
{
    static void Main()
    {
        Publisher publisher = new Publisher();
        Subscriber subscriber = new Subscriber();

        subscriber.Subscribe(publisher);

        publisher.RaiseEvent();  // Raise the event
    }
}
