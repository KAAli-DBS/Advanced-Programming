using System;
using System.Text.Json;

using System.Collections.Generic;
using PhoneBook_BS;

public class PhoneBook
{
    // Save the list of contacts to a JSON file
    public static void SaveToJson(List<Contact> contacts, string filePath)
    {
        string jsonData = JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, jsonData);
        Console.WriteLine("Phonebook saved to JSON file successfully!");
    }

    // Load contacts from a JSON file
    public static List<Contact> LoadFromJson(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("No existing file found. Returning empty phonebook.");
            return new List<Contact>();
        }

        string jsonData = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<Contact>>(jsonData);
    } 
    
    public static Contact BinarySearch(List<Contact> contacts, string targetName)
    {
        int left = 0;
        int right = contacts.Count - 1;
        int comparisonCount = 0;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            comparisonCount++; // Count each comparison made

            int comparison = string.Compare(contacts[mid].Name, targetName, StringComparison.OrdinalIgnoreCase);

            // comparison < 0 → mid name comes before target → search right half

            // comparison > 0 → mid name comes after target → search left half

            if (comparison == 0)
            {
                Console.WriteLine($"Element found at index {mid}");
                Console.WriteLine($"Total comparisons made: {comparisonCount}");
                return contacts[mid];
            }       
            else if (comparison > 0)
            {
                right = mid - 1;   // Search left half
            }   
            else
            {
                left = mid + 1;   // Search right half
            }
        }
        // If not found
        Console.WriteLine($"Element not found after {comparisonCount} comparisons.");   
        return null; 
    }
    
    public static void Main(string[] args)
    {   
        
        string filePath = "phonebook.json";

        List<Contact> phoneBook = LoadFromJson(filePath);
        // If no data exists, create initial contacts
        /*
        if (phoneBook.Count == 0)
        {
            phoneBook = new List<Contact>
            {
                new Contact("Alice", "123-456-7890"),
                new Contact("Charlie", "345-678-9012"),
                new Contact("David", "456-789-0123"),
                new Contact("Eve", "567-890-1234"),
                new Contact("Bob", "234-567-8901")
            };

            SaveToJson(phoneBook, filePath); // Save initial data
        }
        */

        // If no data exists, let the user add contacts
        if (phoneBook.Count == 0)
        {
            Console.WriteLine("No contacts found. Let's add some!");
            Console.Write("How many contacts do you want to add? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nEnter details for contact {i + 1}:");

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Phone Number: ");
                string phoneNumber = Console.ReadLine();

                phoneBook.Add(new Contact(name, phoneNumber));
            }

            SaveToJson(phoneBook, filePath); // Save new contacts
        }

        phoneBook.Sort((x, y) => string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase));
            
        // string searchName = "Charlie";
        // string searchName = "David";

        // Ask the user for a name to search
        Console.Write("\nEnter the name to search: ");
        string searchName = Console.ReadLine();

        Contact foundContact = BinarySearch(phoneBook, searchName);

        if (foundContact != null)
        {
            Console.WriteLine($"Found: {foundContact.Name}, Phone: {foundContact.PhoneNumber}");
        }
        else
        {
            Console.WriteLine($"{searchName} was not found in the phonebook.");
        }
    }
}


