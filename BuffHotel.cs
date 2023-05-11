using System;
using System.Collections.Generic;

namespace BuffHotel
{
    class Options
    {
        public string? username;
        public string? password;
        private static Dictionary<string, string> UserLog = new Dictionary <string, string>(); //login dict
        //I created a dictionary that matches the Room# with Capacity# hence the name RoomCapacity. hopefully this is not confusing. Same with the reserved room and guest name.
        private static Dictionary <int, int> RoomCapacity = new Dictionary<int, int>();
        private static Dictionary <int, string> RoomCustomer = new Dictionary<int, string>();
        private static List <int> ReservedRooms = new List<int>();  
        public Options (Dictionary <string, string> userLog, Dictionary <int, string> roomCustomer)
        {
            UserLog = userLog;
            RoomCustomer = roomCustomer;
            RoomCapacity = new Dictionary<int, int>();
            for (int i = 101; i <= 110; i++)
            {
                if (i <= 105)
                {
                    RoomCapacity[i] = 2;
                }
                else if (i <= 109)
                {
                    RoomCapacity[i] = 3;
                }
                else
                {
                    RoomCapacity[i] = 4;
                }
            }
        }

        public static void CreateAccount()
        {
            string username;
            string password;
            Console.WriteLine("--> Please input new username");
            username = Console.ReadLine();
            while (UserLog.ContainsKey(username))
            {
                Console.WriteLine("Username already in use! Please input a different one.");
                username = Console.ReadLine();
            }
            Console.WriteLine("--> Please input new password");
            password = Console.ReadLine();
            if (password == "Q" || password == "q")
            {
                Console.WriteLine("Please input a different password");
                password = Console.ReadLine();
            }
            UserLog.Add(username, password);
            
        }

        public static bool LogIn()
        {   
            Console.WriteLine("Do you have an account with Buff Hotel? Y/N");
            string answer = Console.ReadLine().ToLower();
            while (answer == "n" || answer == "no")
            {
                Options.CreateAccount();
                break;
            }
            
            Console.WriteLine("--> Please input username");
            string username = Console.ReadLine();
            Console.WriteLine("--> Please input password");
            string password = Console.ReadLine();
            if (string.IsNullOrEmpty(username))
            {
                Console.WriteLine("Username cannot be empty!");
                return false;
            }
            if (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Password cannot be empty!");
                return false;
            }
            if (UserLog != null && UserLog.ContainsKey(username))
            {
                if (UserLog[username] == password)
                {
                    Console.WriteLine("Login Successful!");
                    Console.WriteLine($"Hello {username}!");
                    return true;
                }
                while (UserLog[username] != password)
                {
                    Console.WriteLine("Password incorrect! Retry or press Q to quit!");
                    password = Console.ReadLine();
                    if (UserLog[username] == password)
                    {
                        Console.WriteLine("Login Successful!");
                        Console.WriteLine($"Hello {username}");
                    }
                    else if (password == "Q" || password == "q")
                    {   
                        Console.WriteLine("Login Failed!");
                        return false;
                        
                    }
                }
            }
            Console.WriteLine("This username does not exist, would you like to create an account? Y/N");
            string choice = Console.ReadLine().ToLower();
            if (choice == "y" || choice == "yes")
            {
                Options.CreateAccount();
                return true;
            }
            else
            {
                Console.WriteLine("Login Failed!");
                return false;
            }
        }

        public Dictionary<int, int> GetRoomCapacity()
        {
            return RoomCapacity;
        }
        public void ShowAvailableRooms()
        {
            int availableCount = 0;
            Dictionary<int, int> RoomCapacity = GetRoomCapacity();
            foreach (KeyValuePair<int, int> room in RoomCapacity)
            {
                if (!ReservedRooms.Contains(room.Key))
                {
                    Console.WriteLine($"+ Room number: {room.Key}; Capacity: {room.Value}");
                    availableCount++;
                }
            }
            Console.WriteLine($"Number of Available Rooms: {availableCount}"); 
        }

        public void CheckIn()
        {   
            int availableCount = 0;
            Console.WriteLine("Input number of people: ");
            int numGuests = Convert.ToInt32(Console.ReadLine());
            foreach (KeyValuePair<int, int> room in RoomCapacity)
            {
                
                if (numGuests <= room.Value && !ReservedRooms.Contains(room.Key))
                {
                    Console.WriteLine($"+ Room number: {room.Key}; Capacity: {room.Value}");
                    availableCount++;
                }  
            }
            if (availableCount == 0)
            {
                Console.WriteLine("No suitable room at this time.");
                return;
            }
            Console.WriteLine($"----Number of Available Rooms: {availableCount}----");
            Console.WriteLine("--> Input Room Number: ");
            int roomNum = Convert.ToInt32(Console.ReadLine());
            if (!ReservedRooms.Contains(roomNum))
            {
                Console.WriteLine("--> Input Customer Name: ");
                string custName = Console.ReadLine();
                Console.WriteLine("--> Input Customer Email: ");
                string custEmail = Console.ReadLine();
                Console.WriteLine("Check-In Successful!");
                RoomCustomer.Add(roomNum, custName);
                ReservedRooms.Add(roomNum);
            }
        }

        public static Dictionary<int, string> GetRoomCustomer()
        {
            return RoomCustomer;
        }
        public static void ShowReservedRooms()
        {
            Dictionary<int, string> RoomCustomer = GetRoomCustomer();
            Console.WriteLine("----Reserved Rooms----");
            foreach (KeyValuePair<int, string> room in RoomCustomer)
            {
                Console.WriteLine($"+ Room Number: {room.Key}; Customer: {room.Value}");
            }
        }
        public void CheckOut()
        {
            Console.WriteLine("--> Please input room number: ");
            int roomNum = Convert.ToInt32(Console.ReadLine());
            foreach (KeyValuePair<int, string> room in RoomCustomer)
            {
                if (roomNum == room.Key)
                {
                    Console.WriteLine($"+ Room Number: {room.Key}; Customer: {room.Value}");
                    Console.WriteLine("Please confirm the customer name and input Y to continue Check-Out OR input any key to cancel.");
                    string confirmName = Console.ReadLine();
                    string confirmation = Console.ReadLine().ToLower();
                    if (confirmName == room.Value && confirmation == "y")
                    {
                        Console.WriteLine("Check-Out Successful!");
                        RoomCustomer.Remove(room.Key);
                        ReservedRooms.Remove(room.Key);
                        Options.ShowReservedRooms();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Check-Out Cancelled");
                        return;
                    }
                }
            }
            if (!RoomCustomer.ContainsKey(roomNum))
            {
                Console.WriteLine("Could not find customer record of this room.");
                return;
            }
        }
            
        public static void LogOut()
        {   
            Console.WriteLine("Logging Out");
            Environment.Exit(0);
        }
    } 

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----CIDM2315 Final Project: Caleb Withers----");
            Console.WriteLine("------------Welcome to Buff Hotel------------");

            Dictionary<string, string> userLog = new Dictionary<string, string>();
            userLog.Add("admin", "admin");
            Dictionary<int, string> roomCustomer = new Dictionary<int, string>();
            Options options = new Options(userLog, roomCustomer);
            bool isLoggedIn = false;

            while (!isLoggedIn)
            {
                isLoggedIn = Options.LogIn();
                if (!isLoggedIn)
                {
                    Console.WriteLine("Invalid login credentials. Please try again.");
                }
            }
   
                  
            do
            {
                Console.WriteLine("**********************");
                Console.WriteLine("--> Please select:");
                Console.WriteLine("1. Show Available Room");
                Console.WriteLine("2. Check-In");
                Console.WriteLine("3. Show Reserved Room");
                Console.WriteLine("4. Check-Out");
                Console.WriteLine("5. Log Out");
                Console.WriteLine("**********************");
                int option = Convert.ToInt32(Console.ReadLine());
                
                
                switch (option)
                {
                    case 1:
                        options.ShowAvailableRooms();
                        break;
                    case 2:
                        options.CheckIn();
                        break;
                    case 3:
                        Options.ShowReservedRooms();
                        break;
                    case 4:
                        options.CheckOut();
                            
                        break;
                    case 5:
                        Options.LogOut();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
         
            } while (isLoggedIn);
            
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }    
}      