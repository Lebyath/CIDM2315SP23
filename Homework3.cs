namespace Homework3;
class Program
{
    static void Main(string[] args)
    {
        /*Q1: Write a C# program that:
        -takes as input a number N, if the number N is
        a prime number, print "N is prime", else print
        "N is non-prime".
        */
        Console.Write("Input an integer: ");
        int N = Convert.ToInt16(Console.ReadLine());
        bool isPrime = true;

        for (int X = 2; X < N; X++)
        {
            if (N % X == 0)
            {
                isPrime = false;
                break;
            }
        }
       Console.WriteLine(isPrime ? $"{N} is prime" : $"{N} is non-prime");

        /*
        Q2: Write a C# program:
        -input an integer N
        -and it prints on screen 
        the following square pattern,
        where the number of rows and columns is equal to N
        */

        Console.WriteLine("Assign an int value to Num: ");
        int Num = Convert.ToInt16(Console.ReadLine());

        for (int Y = 0; Y < Num; Y++)
        {
            for (int Z = 0; Z < Num; Z++)
            {
                Console.Write("#");
            }
            Console.WriteLine();
        }

        /*
        Q3: Write a C# program
        -input an integer number N
        -and it prints on screen the following square pattern,
         where the number of rows is equal to N
        */
        Console.WriteLine("Assign an int value to Number: ");
        int Number = Convert.ToInt16(Console.ReadLine());

        for (int A = 0; A < Number; A++)
        {
            for (int B = 0; B <= A; B++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }



        /*
        Bonus: Write a C# program
        -input a number N
        -and it prints on screen the following
        square pattern, where the number of rows
        is equal to N
        */
        Console.WriteLine("Assign an int value to Nm: ");
        int Nm = Convert.ToInt16(Console.ReadLine());

        for (int C = 1; C <= Nm; C++)
        {
            for (int D = 1; D < Nm - C + 1; D++)
            {
                Console.Write(" ");
            }
            for (int D = 1; D <= C; D++)
            {
                Console.Write(C);
            }
            Console.WriteLine();
        }

    }
}