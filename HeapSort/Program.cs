using System;

class HeapSortDemo
{
    // Heapify a subtree rooted at index i
    static void Heapify(int[] arr, int n, int i)
    {
        int largest = i; // Initialize largest as root
        int l = 2 * i + 1; // left child
        int r = 2 * i + 2; // right child

        if (l < n && arr[l] > arr[largest])
            largest = l;

        if (r < n && arr[r] > arr[largest])
            largest = r;

        if (largest != i)
        {
            int temp = arr[i];
            arr[i] = arr[largest];
            arr[largest] = temp;

            // Recursively heapify the affected subtree
            Heapify(arr, n, largest);
        }
    }

    // Main Heap Sort function
    static void HeapSortArray(int[] arr)
    {
        int n = arr.Length;

        // Build heap (rearrange array)
        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(arr, n, i);

        // Extract elements one by one
        for (int i = n - 1; i > 0; i--)
        {
            // Move current root to end
            int temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;

            // Heapify reduced heap
            Heapify(arr, i, 0);
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
    static void Main()
    {
        int[] arr = { 12, 11, 13, 5, 6, 7 };
        Console.WriteLine("Original Array:");
        PrintArray(arr);

        HeapSortArray(arr);

        Console.WriteLine("Sorted Array:");
        PrintArray(arr);
    }
}
