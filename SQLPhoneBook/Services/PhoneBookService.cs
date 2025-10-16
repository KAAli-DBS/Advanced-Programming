using System;
using System.Collections.Generic;
using PhoneBook_BS;

namespace PhoneBook_BS.Services
{
    public static class PhoneBookService
    {
        // Binary search (in-memory)
        public static Contact BinarySearch(List<Contact> contacts, string targetName)
        {
            int left = 0;
            int right = contacts.Count - 1;
            int comparisonCount = 0;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                comparisonCount++;

                int comparison = string.Compare(contacts[mid].Name, targetName, StringComparison.OrdinalIgnoreCase);
                if (comparison == 0)
                {
                    Console.WriteLine($"Element found at index {mid}");
                    Console.WriteLine($"Total comparisons made: {comparisonCount}");
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

            Console.WriteLine($"Element not found after {comparisonCount} comparisons.");
            return null;
        }

        // Sort contacts by name
        public static void SortContacts(List<Contact> contacts)
        {
            contacts.Sort((x, y) => string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase));
        }
    }
}