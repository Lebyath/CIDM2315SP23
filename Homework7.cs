namespace Homework7;

class Customer 
{
    private int cus_id;
    public string cus_name;
    public int cus_age;
    
    public Customer(int cus_id, string cus_name, int cus_age) //constructor used to assign id, name and age to customer when an object is created
    {
        this.cus_id = cus_id;
        this.cus_name = cus_name;
        this.cus_age = cus_age;
    }
    
    public void ChangeID(int new_id) //method used to change customer id 
    {
        cus_id = new_id;
    }
    
    public void PrintCusInfo() //method used to print customer information (id, name, age)
    {
        Console.WriteLine($"Customer ID: {cus_id}, Name: {cus_name}, Age: {cus_age}");
    }
    
    public void CompareAge(Customer objCustomer) //method used to compare age
    {
        if (this.cus_age > objCustomer.cus_age) 
        {
            Console.WriteLine($"{this.cus_name} is older");
        } 
        else if (this.cus_age < objCustomer.cus_age) 
        {
            Console.WriteLine($"{objCustomer.cus_name} is older");
        } 
        else 
        {
            Console.WriteLine($"{this.cus_name} and {objCustomer.cus_name} are the same age");
        }
    }
}

class Program 
{
    static void Main(string[] args) 
    {   //in the main method, create two customers with 
        Customer cus1 = new Customer(110, "Alice", 28);
        Customer cus2 = new Customer(111, "Bob", 30);
        
        //print their information by calling PrintCusInfo() method
        cus1.PrintCusInfo();
        cus2.PrintCusInfo();
        
        //update customer's ID to 220, and 221, respectively.
        cus1.ChangeID(220);
        cus2.ChangeID(221);
        
        //then print their information again
        cus1.PrintCusInfo();
        cus2.PrintCusInfo();
        
        //finally, compare their age and print the older customer's name
        cus1.CompareAge(cus2);
    }
}