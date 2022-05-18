using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    internal class Program
    {
        public static void ErrorAction(string err)
        {
            Console.WriteLine("!!! " + err + " !!!");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter username and password:");
            string username = Console.ReadLine();
            string password = Console.ReadLine();
            LoginValidation loginValidation = new LoginValidation(username, password, ErrorAction);
            User user = null;

            if (loginValidation.ValidateUserInput(ref user) == true)
            {
                switch (user.userRole)
                {
                    case 0:
                        Console.WriteLine("User is Anonymous");
                        break;
                    case 1:
                        Console.WriteLine("User is Admin");
                        break;
                    case 2:
                        Console.WriteLine("User is Inspector");
                        break;
                    case 3:
                        Console.WriteLine("User is Professor");
                        break;
                    case 4:
                        Console.WriteLine("User is Student");
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }

                if (user.userRole == 1)
                {
                    adminMenu();
                }
            }
        }

        public static void adminMenu()
        {
            bool tr = true;

            while (tr)
            {
                Console.WriteLine("Select option: \n0: Exit\n1: Change user's role\n2: Change user's activity\n3: List with users\n4: Show log activity\n5: Show current activity");
                int input = Int32.Parse(Console.ReadLine());

                switch (input)
                {
                    case 0:
                        tr = false;
                        break;
                    case 1:
                        Console.WriteLine("Enter user's name and new role");
                        string username = Console.ReadLine();
                        Int32 role = Int32.Parse(Console.ReadLine());
                        UserData.AssignUserRole(username, (UserRoles)role);
                        break;
                    case 2:
                        Console.WriteLine("Enter user's name and activity end-date in SPECIAL FORMAT");
                        string name = Console.ReadLine();
                        DateTime dateTime = DateTime.Parse(Console.ReadLine());
                        UserData.SetUserActiveTo(name, dateTime);

                        foreach (User user in UserData.testUsers)
                        {
                            Console.WriteLine(user.ToString());
                        }
                        break;
                    case 3:
                        foreach (User user in UserData.testUsers)
                        {
                            Console.WriteLine(user.ToString());
                        }
                        break;
                    case 4:
                        StreamReader streamReader = new StreamReader("test.txt");
                        string line;

                        while ((line = streamReader.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                        streamReader.Close();
                        break;
                    case 5:
                        StringBuilder stringBuilder = new StringBuilder();
                        string filter = Console.ReadLine();
                        IEnumerable<string> currentActivities = Logger.getCurrentSessionActivities(filter);
                        foreach (string activity in currentActivities)
                        {
                            stringBuilder.Append(activity).Append(Environment.NewLine);
                        }
                        Console.WriteLine(stringBuilder.ToString().Trim());
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
            }
        }
    }
}
