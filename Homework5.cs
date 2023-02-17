/*Q1: Write a C# method that:
        -get 2 integers as inputs from the keyboard
        -returns the largest one
        -call this method in Main() and print the result.*/

        /*Q2: Write a C# method:
        -get 4 integers as inputs from the keyboard
        -and returns the largest one
        -you should use the method from Q1 to solve this exercise
        (You will lose 2 points if didn't use the method from Q1 to answer this question)
        -call this method in Main() and print the result.*/

        /*Q3: Please implement the following methods to
        design an account-creating process:
        1. static bool checkAge(int birth_year){
            //calculate the age based on the birth_year (age = 2022 - birthyear)
            //if age >= 18, return true;
            //else return false;
            }//1 point

        2. static void createAccount(){
            //ask use to input username
            //ask user to input password
            //ask user to input password again
            //ask user to input birthyear
            //call checkAge(birthyear) method to check if age
            is greater than 18
            //if checkAge(birthyear) returns true,
                //then check if two passwords are same, if passwords are the same
                print "Account is created successfully"
                //else print "Wrong Password"
            //if checkAge(birthyear) returns false, print "Could not create an account"
            }//4 points
        }*/
namespace Homework5;
 
class Program
{
    static void Main(string[] args)
    {
        //Q1
        Console.WriteLine("Please enter an integer: ");
        int a = Convert.ToInt16(Console.ReadLine());

        Console.WriteLine("Please enter a second integer: ");
        int b = Convert.ToInt16(Console.ReadLine());

        int maxTwo = LargestofTwo(a, b);

        Console.WriteLine($"The largest number is: {maxTwo}");

        //Q2
        Console.WriteLine("Please enter an integer: ");
        int a2 = Convert.ToInt16(Console.ReadLine());

        Console.WriteLine("Please enter a second integer: ");
        int b2 = Convert.ToInt16(Console.ReadLine());

        Console.WriteLine("Please enter a third integer: ");
        int c = Convert.ToInt16(Console.ReadLine());

        Console.WriteLine("Please enter a fourth integer: ");
        int d = Convert.ToInt16(Console.ReadLine());

        int maxFour = LargestofFour(a2, b2, c, d);
        Console.WriteLine($"The largest number is: {maxFour}");

        //Q3
        createAccount();
    }

    //Q1
    static int LargestofTwo(int a, int b)
    {   
        int maxNum = (a > b) ? a : b;
        return maxNum;
    }

    //Q2
    static int LargestofFour(int a, int b, int c, int d)
    {   
        int maxNum = LargestofTwo(LargestofTwo(a, b), LargestofTwo(c, d));
        return maxNum;
    }

    //Q3
    static bool checkAge(int birth_year)
    {
        int age = 2022 - birth_year;
        if (age >= 18)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static void createAccount()
    {
        Console.WriteLine("Please enter your username: ");
        string username = Console.ReadLine();

        Console.WriteLine("Please enter your password: ");
        string password1 = Console.ReadLine();

        Console.WriteLine("Please reenter your password: ");
        string password2 = Console.ReadLine();

        Console.WriteLine("Please enter your birth year: ");
        int birth_year = Convert.ToInt16(Console.ReadLine());

        if (checkAge(birth_year))
        {
            if (password1 == password2)
            {
                Console.WriteLine("Account was created successfully");
            }
            else
            {
                Console.WriteLine("Wrong password");
            }
        }
        else
        {
            Console.WriteLine("Could not create account");
        }
    }
}
