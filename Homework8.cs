namespace Homework8;

class Program
{
    //Q1: Calculate the sum of elements in a given int_array (4 points)
    public static void ArraySum(int[] int_array)
    {
        int num = 0;
        for (int i = 0; i < int_array.Length; i++)
        {
            num += int_array[i];
        }
        Console.WriteLine($"The Sum of int_array is: {num}");
    }

    //Q2.1: given a 2d array, print all the odd elements 
    public static void PrintAllOddNumbers(int[,] array_2d)
    {
        foreach (int num in array_2d)
        {
            if (num % 2 != 0){Console.Write(num + " ");}  
        }
    }

    //Q2.2: given a 2d array, return the sum of all elements 
    public static int ElementSum(int[,] array_2d)
    {
        int total = 0;
        foreach (int num in array_2d)
        {
            total += num;
        }
        return total;
    }

    //Q2.3: given a 2d array, double its element values and return it
    public static int[,] DoubleArray(int[,] array_2d)
    {
        int[,] dub_array = new int[array_2d.GetLength(0), array_2d.GetLength(1)];
        
        for (int A = 0; A < array_2d.GetLength(0); A++)
        {
            for (int B = 0; B < array_2d.GetLength(1); B++)
            {
                dub_array[A, B] = array_2d[A, B] * 2;
            }
        }
        return dub_array;
    }
        
    static void Main(string[] args)
    {
        //*** DO NOT CHANGE THE CODE IN THE MAIN ***
        int[] int_array = {11, 23, 31, 42, 53};
        ArraySum(int_array);

        //Input 2d array for Q2
        int [,] array_2d = {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };

        //Test Q2.1
        PrintAllOddNumbers(array_2d);

        //Test Q2.2
        Console.WriteLine($"\nSum of 2d array: {ElementSum(array_2d)}");

        //Test Q2.3
        
        int[,] Q2_3 = DoubleArray(array_2d);
        Console.WriteLine("The new 2d array:");
        foreach (int num in Q2_3)
        {
            Console.Write(num + " ");
        }
        
    }
}