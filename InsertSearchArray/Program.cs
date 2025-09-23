using System;

class Program
{
    public static void Main()
    {
        Console.WriteLine("Choose a program to run:");
        Console.WriteLine("1. Linear Search");
        Console.WriteLine("2. Insert Element");
        Console.Write("Enter your choice (1-2): ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                LinearSearch.Run();
                break;
            case "2":
                Insertion.Run();
                break;
            default:
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                break;
        }
    }
}