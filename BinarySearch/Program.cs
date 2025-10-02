using System;

class Program
{
    static int BinarySearch(int[] arr, int x)
    {
        int low = 0;
        int high = arr.Length - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;

            if (arr[mid] == x)
                return mid;          // Element found
            else if (arr[mid] < x)
                low = mid + 1;       // Search right half
            else
                high = mid - 1;      // Search left half
        }

        return -1;  // Element not found
    }

    static void Main()
    {
        int[] numbers = { 2, 5, 8, 12, 16, 23, 38, 45 };
        int target = 23;

        int result = BinarySearch(numbers, target);

        if (result != -1)
            Console.WriteLine($"Element found at index {result}");
        else
            Console.WriteLine("Element not found");
    }
}
