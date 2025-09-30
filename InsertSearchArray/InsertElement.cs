using System;

class Insertion
{
    public static void Run()
    {
        // Declare an array of integers with a fixed size
        int[] elements = new int[20];
        // Assign values to the elements
        elements[0] = 22;
        elements[1] = 46;
        elements[2] = 10;
        elements[3] = 80;
        elements[4] = 55;

        int newElement = 70; // New element to insert
        int currentSize = 5; // Current size of the array
        int insertPosition = 2; // Position where the new element will be inserted

        // Print elements before insertion
        Console.WriteLine("Before Insertion:");
        for (int i = 0; i < currentSize; i++)
        
        {
            Console.Write(elements[i] + " ");
        }
        
        Console.WriteLine();

        // Call the insertElement function
        InsertElement(elements, currentSize, newElement, insertPosition);
        currentSize++; // Increase the current size after insertion

        // Print elements after insertion
        Console.WriteLine("After Insertion:");
        for (int i = 0; i < currentSize; i++)
        {
            Console.Write(elements[i] + " ");
        }
        Console.WriteLine();
    }

    // Function to insert a new element into the array
    static void InsertElement(int[] elements, int currentSize, int newElement, int insertPosition)
    {
        // Shift elements to the right
        for (int i = currentSize - 1; i >= insertPosition; i--)
        {
            elements[i + 1] = elements[i];
        }
        // Insert the new element at the specified position
        elements[insertPosition] = newElement;
    }
}