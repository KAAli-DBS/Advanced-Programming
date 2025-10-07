using System;
using System.Collections.Generic;
using PhoneBook_BS;

public class PhoneBook
{
    
    public static Contact BinarySearch(List<Contact> contacts, string targetName)
    {
        int left = 0;
        int right = contacts.Count - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            int comparison = string.Compare(contacts[mid].Name, targetName, StringComparison.OrdinalIgnoreCase);

            if (comparison == 0)
            {
                return contacts[mid];
            }       
            else if (comparison > 0)
            {
                right = mid - 1;
            }   
            else
            {
                left = mid + 1;
            }
        }

        return null; 
    }
    public static void Main(string[] args)
    {     
        List<Contact> phoneBook = new List<Contact>
        {
            new Contact("Alice", "123-456-7890"),
            new Contact("Charlie", "345-678-9012"),
            new Contact("David", "456-789-0123"),
            new Contact("Eve", "567-890-1234"),
            new Contact("Bob", "234-567-8901")   // 4 index 
            
        };
    
        phoneBook.Sort((x, y) => string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase));
            
        string searchName = "bob";

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


