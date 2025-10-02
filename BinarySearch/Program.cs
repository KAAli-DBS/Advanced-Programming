using System;

class Program
{
    static int BinarySearch(int[] array, int x)
    {
        // Lower index of the Array 
        int low = 0;
        // Upper bound of the Array 
        int high = array.Length - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;
            Console.WriteLine(array[mid]);

            if (array[mid] == x)
                {
                // Element found at mid location 
                return mid; 
                }     

            else if (array[mid] < x)
                // Search right half
                low = mid + 1;       
            else
                // Search left half
                high = mid - 1;      
        }

        return -1;  
    }
    static void Main()
    {
        int[] numbers = { 2, 5, 8, 12, 16, 23, 38, 56, 72, 91 };
        int target = 115;

        int result = BinarySearch(numbers, target);

        if (result != -1)
            Console.WriteLine($"Element found at index {result}");
        else
            Console.WriteLine("Element not found");
    }
}
