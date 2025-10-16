using System;
using PhoneBook_BS;
using PhoneBook_BS.Database;
using PhoneBook_BS.Services;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Database.Initialize();

        List<Contact> phoneBook = Database.GetAllContacts();

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

                var contact = new Contact(name, phoneNumber);
                Database.AddContact(contact);
                phoneBook.Add(contact);
            }
        }

        PhoneBookService.SortContacts(phoneBook);

        Console.Write("\nEnter the name to search: ");
        string searchName = Console.ReadLine();

        var foundContact = PhoneBookService.BinarySearch(phoneBook, searchName);

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
