namespace Homework9;

class Student //1. Create a student class with:
{
    private int studentID; //private int
    private string studentName; //private string
    public static List<Student> student_list = new List<Student>(); //public student list
    public void PrintInfo() // print info method
    {
        Console.WriteLine($"Student ID: {studentID}, Student Name: {studentName}");
    }
    public Student(int inputID, string inputName) //Student constructor
    {
        studentID = inputID;
        studentName = inputName;
        student_list.Add(this);
    }
    public string GetName() //my extra GetName() method for retrieving the studentName
    {
        return studentName;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Student alice = new Student(111, "Alice"); //2. In the Program class, the Main method: create 4 students:
        Student bob = new Student(222, "Bob");
        Student cathy = new Student(333, "Cathy");
        Student david = new Student(444, "David");

        Dictionary<string, double> gradebook = new Dictionary<string, double>(); //3. Create a Dictionary named gradebook to hold the student's names and GPAs
        foreach (var student in Student.student_list)
        {
            double GPA = gradebook.ContainsKey(student.GetName()) ? gradebook[student.GetName()] : 0;
            gradebook[student.GetName()] = GPA;
        }
        gradebook["Alice"] = 4.0;
        gradebook["Bob"] = 3.6;
        gradebook["Cathy"] = 2.5;
        gradebook["David"] = 1.8; 

        if (!gradebook.ContainsKey("Tom")) //4. Check if "Tom" has a record in gradebook. If "Tom" is NOT in the gradebook, insert Tom:
        {
            gradebook.Add("Tom", 3.3);
            Student tom = new Student(555, "Tom"); //I created a tom object because his GPA is higher than the average(3.04) and their GPA is greater than average as well(3.3).
        }
        
        double totalGPA = 0; //5. Calculate the average GPA of all students, and print out the average GPA.
        foreach (KeyValuePair<string, double> stuGPA in gradebook)
        {
            totalGPA += stuGPA.Value;
        }
        double averageGPA = totalGPA / gradebook.Count;
        Console.WriteLine($"The average GPA is: {averageGPA}");

        foreach (KeyValuePair<string, double> stuGPA in gradebook) //6. Finally, print out information about students whose GPA is greater than the average GPA.
        {
            if (stuGPA.Value > averageGPA)
            {
                foreach (var student in Student.student_list)
                {
                    string name = stuGPA.Key;
                    if (student.GetName() == name)
                    {
                        student.PrintInfo();
                        break;
                    }                  
                }        
            }
        }
    }
}
