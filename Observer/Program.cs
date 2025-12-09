using System;
using System.Collections.Generic;

class Program
{
    // The Observer interface
    interface ISubscriber
    {
        void Update(string magazineIssue);
    }

    // The Subject interface
    interface IPublisher
    {
        void Subscribe(ISubscriber subscriber);
        void Unsubscribe(ISubscriber subscriber);
        void NotifySubscribers();
    }

    // Concrete Subject
    class MagazinePublisher : IPublisher
    {
        private List<ISubscriber> _subscribers = new List<ISubscriber>();
        private string _latestIssue;

        public void PublishNewIssue(string issue)
        {
            _latestIssue = issue;
            Console.WriteLine($"Publisher: New magazine issue published: {issue}");
            NotifySubscribers();
        }

        public void Subscribe(ISubscriber subscriber)
        {
            _subscribers.Add(subscriber);
            Console.WriteLine("Subscriber added.");
        }

        public void Unsubscribe(ISubscriber subscriber)
        {
            _subscribers.Remove(subscriber);
            Console.WriteLine("Subscriber removed.");
        }

        public void NotifySubscribers()
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.Update(_latestIssue);
            }
        }
    }

    // Concrete Observer
    class MagazineSubscriber : ISubscriber
    {
        private string _name;

        public MagazineSubscriber(string name)
        {
            _name = name;
        }

        public void Update(string magazineIssue)
        {
            Console.WriteLine($"{_name} received the latest issue: {magazineIssue}");
        }
    }

    static void Main(string[] args)
    {
        // Create publisher
        MagazinePublisher publisher = new MagazinePublisher();

        // Create subscribers
        MagazineSubscriber mark = new MagazineSubscriber("Mark");
        MagazineSubscriber ruffini = new MagazineSubscriber("Ruffini");

        // Subscribe to the publisher
        publisher.Subscribe(mark);
        publisher.Subscribe(ruffini);

        // Publisher releases a new magazine issue
        publisher.PublishNewIssue("July 2024 Edition");

        // Ruffini unsubscribes
        publisher.Unsubscribe(ruffini);

        // Publisher releases another new magazine issue
        publisher.PublishNewIssue("August 2024 Edition");
    }
}
