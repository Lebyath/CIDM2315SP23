/*The lineear line equation is: Z = 4X**2+3Y, 
when X=2.5, Y=3.3, write a program to:
    -calculate the value of Z and print it out.

*/
namespace Homework1;
class Program
{
    static void Main(string[] args)
    {
        // my code for Homework1

        //declare variables
        double X = 2.5;
        double Y = 3.3;

        //write the equation
        double Z = 4 * (X * X) + (3 * Y);

        //print the answer
        Console.WriteLine($"The value of Z is: {Z}");
    }
}
