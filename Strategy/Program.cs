using System;

class Program
{
    // Strategy interface
    interface ITransportStrategy
    {
        void SelectRoute();
    }

    // Concrete strategies
    class CycleStrategy : ITransportStrategy
    {
        public void SelectRoute()
        {
            Console.WriteLine("You chose to go by cycle. It's eco-friendly, free, but slow.");
        }
    }

    class BusStrategy : ITransportStrategy
    {
        public void SelectRoute()
        {
            Console.WriteLine("You chose to go by bus. It's affordable but takes moderate time.");
        }
    }

    class CarStrategy : ITransportStrategy
    {
        public void SelectRoute()
        {
            Console.WriteLine("You chose to go by car. It's fast but expensive.");
        }
    }

    // Context class
    class RouteSelector
    {
        private ITransportStrategy _strategy;

        public void SetStrategy(ITransportStrategy strategy)
        {
            _strategy = strategy;
        }

        public void ExecuteStrategy()
        {
            _strategy.SelectRoute();
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Choose your mode of transport to the airport:");
        Console.WriteLine("1. Cycle (Free, Slow)");
        Console.WriteLine("2. Bus (Affordable, Moderate Time)");
        Console.WriteLine("3. Car (Expensive, Fast)");
        Console.Write("Enter your choice (1-3): ");

        int choice = int.Parse(Console.ReadLine());

        RouteSelector selector = new RouteSelector();

        switch (choice)
        {
            case 1:
                selector.SetStrategy(new CycleStrategy());
                break;
            case 2:
                selector.SetStrategy(new BusStrategy());
                break;
            case 3:
                selector.SetStrategy(new CarStrategy());
                break;
            default:
                Console.WriteLine("Invalid choice. Defaulting to cycle.");
                selector.SetStrategy(new CycleStrategy());
                break;
        }

        selector.ExecuteStrategy();
    }
}
