using System;

class LinearSearch
{
    public static void Run()
    {
        int[] array = { 24, 340, 100, 66, 80 };
        int arrayLength = array.Length;
        int searchValue = 80;
        int foundIndex = FindElement(array, arrayLength, searchValue);

        if (foundIndex == -1)
            Console.WriteLine("Element not found");
        else
            Console.WriteLine("Element found at position: " + (foundIndex + 1));
    }

    static int FindElement(int[] array, int length, int value)
    {
        for (int index = 0; index < length; index++)
        {
            if (array[index] == value)
                return index; // Return the index if the value is found
        }
        return -1; // Return -1 if not found
    }
}