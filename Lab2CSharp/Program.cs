using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Choose a task:");
        Console.WriteLine("1. Calculate the average of even elements below the main diagonal.");
        Console.WriteLine("2. Replace all elements of the array that are less than a specified number with that number.");
        Console.WriteLine("3. Find the minimum element in each column and store the data in a new array.");
        Console.WriteLine("4. Print the indices of all minimum elements in a sequence of real numbers.");
        Console.WriteLine("5. Exit the program.");
        Console.Write("Your choice: ");

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
            case 5:
                Console.WriteLine("Program terminated.");
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    static void Task1()
    {
        Console.WriteLine("Enter the size of the array (n):");
        int n = int.Parse(Console.ReadLine());
        int[,] array = new int[n, n];

        Console.WriteLine("Enter the elements of the array:");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                array[i, j] = int.Parse(Console.ReadLine());
            }
        }

        int sum = 0;
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (array[i, j] % 2 == 0)
                {
                    sum += array[i, j];
                    count++;
                }
            }
        }

        double average = count > 0 ? (double)sum / count : 0;

        Console.WriteLine($"The average of even elements below the main diagonal: {average}");
    }

    static void Task2()
    {
        Console.WriteLine("Enter the size of the array:");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];

        Console.WriteLine("Enter the elements of the array:");
        for (int i = 0; i < n; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Enter the target number:");
        int target = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            if (array[i] < target)
            {
                array[i] = target;
            }
        }

        Console.WriteLine("The array after replacement:");
        for (int i = 0; i < n; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }

    static void Task3()
    {
        Console.WriteLine("Enter the number of rows:");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the number of elements in each row:");
        int m = int.Parse(Console.ReadLine());

        int[][] jaggedArray = new int[n][];
        for (int i = 0; i < n; i++)
        {
            jaggedArray[i] = new int[m];
        }

        Console.WriteLine("Enter the elements of the jagged array:");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Row {i + 1}:");
            for (int j = 0; j < m; j++)
            {
                jaggedArray[i][j] = int.Parse(Console.ReadLine());
            }
        }

        int[] minArray = new int[m];
        for (int j = 0; j < m; j++)
        {
            int min = jaggedArray[0][j];
            for (int i = 1; i < n; i++)
            {
                if (jaggedArray[i][j] < min)
                {
                    min = jaggedArray[i][j];
                }
            }
            minArray[j] = min;
        }

        Console.WriteLine("The minimum elements in each column:");
        for (int j = 0; j < m; j++)
        {
            Console.Write(minArray[j] + " ");
        }
        Console.WriteLine();
    }

    static void Task4()
    {
        Console.WriteLine("Enter the number of elements in the sequence:");
        int n = int.Parse(Console.ReadLine());
        double[] sequence = new double[n];

        Console.WriteLine("Enter the elements of the sequence:");
        for (int i = 0; i < n; i++)
        {
            sequence[i] = double.Parse(Console.ReadLine());
        }

        double min = sequence[0];
        for (int i = 1; i < n; i++)
        {
            if (sequence[i] < min)
            {
                min = sequence[i];
            }
        }

        Console.WriteLine("Indices of all minimum elements:");
        for (int i = 0; i < n; i++)
        {
            if (sequence[i] == min)
            {
                Console.Write(i+1 + " ");
            }
        }
        Console.WriteLine();
    }
}
