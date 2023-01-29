namespace Homework2;
class Program
{
    static void Main(string[] args)
    {

        /*question 1: Input grade in letters (A, B, C, D, F)
        print corresponding GPA points
        A:4 B:3 C:2 D:1 F:0
        If the user inputs the wrong letter, then print "Wrong Letter Grade!"
        */
        char grade;
        Console.WriteLine("Please input a letter grade: ");
        grade = Convert.ToChar(Console.ReadLine());
        
        switch(Char.ToUpper(grade)){
            case 'A':
                Console.WriteLine("A: 4");
                break;
            case 'B':
                Console.WriteLine("B: 3");
                break;
            case 'C':
                Console.WriteLine("C: 2");
                break;
            case 'D':
                Console.WriteLine("D: 1");
                break;
            case 'F':
                Console.WriteLine("F: 0");
                break;
            default:
                Console.WriteLine("Wrong Letter Grade!");
                break;
        }

        //question 2: Ask the user to input three numbers and print the smallest value.
        int num1, num2, num3;
        Console.WriteLine("Make sure that you only input an integer for each number!");
        Console.WriteLine("Please input the first num: ");
        num1 = Convert.ToInt16(Console.ReadLine());

        Console.WriteLine("Please input the second num: ");
        num2 = Convert.ToInt16(Console.ReadLine());

        Console.WriteLine("Please input the third num: ");
        num3 = Convert.ToInt16(Console.ReadLine());

        if (num1 < num2){
            if (num1 < num3){
                Console.WriteLine($"The smallest value is: {num1}");
            }
            else{
                Console.WriteLine($"The smallest value is: {num3}");
            }
        }
        else{
            if (num2 < num3){
                Console.WriteLine($"The smallest value is: {num2}");
            }
            else{
                Console.WriteLine($"The smallest value is: {num3}");
            }
        }

        //bonus: Write a C# program that takes as input a year and check if it is a leap year
        int year;
        Console.WriteLine("Please input a year: ");
        year = Convert.ToInt16(Console.ReadLine());

        if (year % 4 == 0){
            if (year % 100 == 0 && year % 400 == 0){
                Console.WriteLine($"{year} is a Leap Year.");
            }
            else if (year % 100 == 0 && year % 400 != 0){
                Console.WriteLine($"{year} is not a Leap Year.");
            }
            else{
                Console.WriteLine($"{year} is a Leap Year.");
            }
        }    
        else{
            Console.WriteLine($"{year} is not a Leap Year.");
        }
        
    }
}
