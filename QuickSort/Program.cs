using System;
using System.Diagnostics;

class QuickSortExample
{
    // Function to swap two elements
    static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    // Partition function
    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high]; // Choose last element as pivot
        int i = low - 1;       // Index of smaller element

        for (int j = low; j <= high - 1; j++)
        {
            // If current element is smaller than pivot
            if (arr[j] < pivot)
            {
                i++;
                Swap(arr, i, j);
            }
        }

        // Place pivot at the correct position
        Swap(arr, i + 1, high);
        return i + 1; // Return partition index
    }

    // QuickSort function
    static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            // pi is partition index
            int pi = Partition(arr, low, high);

            // Recursively sort elements before and after partition
            QuickSort(arr, low, pi - 1);
            QuickSort(arr, pi + 1, high);
        }
    }

    // Function to print array
    static void PrintArray(int[] arr)
    {
        foreach (int i in arr)
            Console.Write(i + " ");
        Console.WriteLine();
    }

    // Main method
    public static void Main()
    {
        int[] arr = { 10, 7, 8, 9, 1, 5, 4, 6, 2, 3 };
        Console.WriteLine("Original Array:");
        Console.WriteLine(string.Join(" ", arr));

        Stopwatch sw = Stopwatch.StartNew(); // Start timer
        QuickSort(arr, 0, arr.Length - 1);
        sw.Stop(); // Stop timer

        Console.WriteLine("\nSorted Array:");
        Console.WriteLine(string.Join(" ", arr));
        Console.WriteLine($"\nQuick Sort Execution Time: {sw.Elapsed.TotalMilliseconds} ms");
    }
}
