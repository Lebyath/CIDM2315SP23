namespace Homework4;
class Program
{
    static void Main(string[] args)
    {
        //Q1
        Console.WriteLine("Please enter your first integer: ");
        int num1 = Convert.ToInt16(Console.ReadLine());
        Console.WriteLine("Please enter your second integer: ");
        int num2 = Convert.ToInt16(Console.ReadLine());
        int lgst_num = LargestofThese(num1, num2);
        Console.WriteLine($"a = {num1}; b = {num2}");
        Console.WriteLine($"The largest number is: {lgst_num}");

        //Q2
        Console.WriteLine("Please enter an integer: ");
        int N = Convert.ToInt16(Console.ReadLine());
        Console.WriteLine("Would you like it facing to the left or to the right? ");
        string dir = Console.ReadLine().ToLower();
        if (dir == null)
        {
            Console.WriteLine("Error: Shape direction must not be null.");
            return;
        }
        PrintDirectedShape(N, dir);
        
    }

    /*
    Q1: Write a C# method that:
    -takes 2 numbers as input
    -returns the largest method
    -call this method in Main() and print the result.
    */
    static int LargestofThese(int a, int b)
    {
        int max_num = (a > b) ? a : b;
        return max_num;
    }

    /*
    Q2: Write a C# method
    -take N as an integer and a shape (left or right)
    -if the shape is left and N = 5, print values of N and
    shape, and a left-side triangle with 5 rows. 
    */
    static void PrintDirectedShape(int N, string dir)
    {
        Console.WriteLine($"N is: {N}; shape is {dir}");
        if (dir == "left")
        {
            for (int x = 1; x <= N; x++)
            {
                for (int y = 1; y <= x; y++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        else if (dir == "right")
        {
            for (int x = 1; x <= N; x++)
            {
                for (int y = 1; y <= N - x; y++)
                {
                    Console.Write(" ");
                }
                for (int z = 1; z <= x; z++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}