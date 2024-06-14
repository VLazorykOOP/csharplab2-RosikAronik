using System;
using System.Linq;
using System.Globalization;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Select a task (1-4) or press 0 to exit:");
            Console.WriteLine("1. Replace all elements less than a given number with that number");
            Console.WriteLine("2. Display the indices of all minimum elements");
            Console.WriteLine("3. Calculate the average of even elements below the main diagonal in a matrix");
            Console.WriteLine("4. Find the minimum element in each column of a jagged array");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Task1();
                    break;
                case 2:
                    Task2();
                    break;
                case 3:
                    Task3();
                    break;
                case 4:
                    Task4();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void Task1()
    {
        Console.WriteLine("Enter the array elements separated by spaces:");
        int[] array = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        Console.WriteLine("Enter the threshold number:");
        int threshold = int.Parse(Console.ReadLine());

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < threshold)
            {
                array[i] = threshold;
            }
        }

        Console.WriteLine("Task 1 result: " + string.Join(", ", array));
    }

    static void Task2()
    {
        Console.WriteLine("Enter the sequence of real numbers separated by spaces:");
        string input = Console.ReadLine();
        double[] array = Array.ConvertAll(input.Split(), s => double.Parse(s, CultureInfo.InvariantCulture));
        double min = array.Min();

        Console.WriteLine("Task 2 result: Indices of minimum elements:");
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == min)
            {
                Console.WriteLine(i+1);
            }
        }
    }

    static void Task3()
    {
        Console.WriteLine("Enter the size of the matrix (n):");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];

        Console.WriteLine("Enter the matrix elements row by row, each element separated by space:");
        for (int i = 0; i < n; i++)
        {
            int[] row = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = row[j];
            }
        }

        int sum = 0;
        int count = 0;

        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (matrix[i, j] % 2 == 0)
                {
                    sum += matrix[i, j];
                    count++;
                }
            }
        }

        double average = (count > 0) ? (double)sum / count : 0;
        Console.WriteLine($"Task 3 result: Average of even elements below the main diagonal: {average}");
    }

    static void Task4()
    {
        Console.WriteLine("Enter the number of rows in the jagged array:");
        int n = int.Parse(Console.ReadLine());
        int[][] jaggedArray = new int[n][];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Enter the elements of row {i + 1} separated by spaces:");
            jaggedArray[i] = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        }

        int maxLength = jaggedArray.Max(row => row.Length);

        int[] minInColumns = new int[maxLength];
        for (int j = 0; j < maxLength; j++)
        {
            minInColumns[j] = int.MaxValue;
            foreach (var row in jaggedArray)
            {
                if (j < row.Length && row[j] < minInColumns[j])
                {
                    minInColumns[j] = row[j];
                }
            }
        }

        Console.WriteLine("Task 4 result: Minimum elements in each column:");
        Console.WriteLine(string.Join(", ", minInColumns));
    }
}
