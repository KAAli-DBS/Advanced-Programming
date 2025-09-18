using System;

class StudentGradesAnalysis
{
    static void Main()
    {
        Console.Write("Enter number of students: ");
        int n = int.Parse(Console.ReadLine());

        int[] marks = new int[n];

        // Input marks
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter marks for student {i + 1}: ");
            marks[i] = int.Parse(Console.ReadLine());
        }

        // Calculate sum, average, min, max
        int sum = 0;
        int max = marks[0];
        int min = marks[0];

        for (int i = 0; i < n; i++)
        {
            sum += marks[i];
            if (marks[i] > max) max = marks[i];
            if (marks[i] < min) min = marks[i];
        }

        double average = (double)sum / n;

        // Count students above average
        int aboveAvgCount = 0;
        foreach (int mark in marks)
        {
            if (mark > average) aboveAvgCount++;
        }

        // Grades distribution
        int gradeA = 0, gradeB = 0, gradeC = 0, gradeD = 0, gradeF = 0;

        foreach (int mark in marks)
        {
            if (mark >= 90) gradeA++;
            else if (mark >= 80) gradeB++;
            else if (mark >= 70) gradeC++;
            else if (mark >= 60) gradeD++;
            else gradeF++;
        }

        // Output results
        Console.WriteLine("\n--- Results ---");
        Console.WriteLine($"Total Students: {n}");
        Console.WriteLine($"Average Marks: {average:F2}");
        Console.WriteLine($"Highest Marks: {max}");
        Console.WriteLine($"Lowest Marks: {min}");
        Console.WriteLine($"Students above average: {aboveAvgCount}");
        Console.WriteLine("Grade Distribution:");
        Console.WriteLine($"A: {gradeA}, B: {gradeB}, C: {gradeC}, D: {gradeD}, F: {gradeF}");
    }
}
