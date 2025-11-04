
// Merge Sort 
using System;
using System.Diagnostics;

class MergeSort
{
    // Function to merge two subarrays of arr[]
    static void merge(int[] arr, int l, int m, int r)
    {
        int n1 = m - l + 1;
        int n2 = r - m;

        // Create temporary arrays
        int[] L = new int[n1];
        int[] R = new int[n2];

        // Copy data to temp arrays
        for (int i = 0; i < n1; i++)
            L[i] = arr[l + i];
        for (int j = 0; j < n2; j++)
            R[j] = arr[m + 1 + j];

        // Merge the temp arrays
        int iIndex = 0, jIndex = 0;
        int k = l;

        while (iIndex < n1 && jIndex < n2)
        {
            if (L[iIndex] <= R[jIndex])
            {
                arr[k] = L[iIndex];
                iIndex++;
            }
            else
            {
                arr[k] = R[jIndex];
                jIndex++;
            }
            k++;
        }

        // Copy remaining elements of L[]
        while (iIndex < n1)
        {
            arr[k] = L[iIndex];
            iIndex++;
            k++;
        }

        // Copy remaining elements of R[]
        while (jIndex < n2)
        {
            arr[k] = R[jIndex];
            jIndex++;
            k++;
        }
    }

    // Function to implement merge sort
    static void mergeSort(int[] arr, int l, int r)
    {
        if (l < r)
        {
            int m = (l + r) / 2;

            mergeSort(arr, l, m);
            mergeSort(arr, m + 1, r);
            merge(arr, l, m, r);
        }
    }

    // Function to print the array
    static void printArray(int[] arr)
    {
        foreach (int i in arr)
            Console.Write(i + " ");
        Console.WriteLine();
    }

    // Main method
    public static void Main()
    {
        int[] arr = { 12, 11, 13, 5, 6, 7, 10, 3, 8, 4 };
        Console.WriteLine("Given Array:");
        Console.WriteLine(string.Join(" ", arr));

        Stopwatch sw = Stopwatch.StartNew();  // Start timer
        mergeSort(arr, 0, arr.Length - 1);
        sw.Stop();  // Stop timer

        Console.WriteLine("\nSorted Array:");
        Console.WriteLine(string.Join(" ", arr));
        Console.WriteLine($"\nMerge Sort Execution Time: {sw.Elapsed.TotalMilliseconds} ms");
    }
}
