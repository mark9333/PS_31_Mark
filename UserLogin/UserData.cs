using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class UserData
    {
        private static List<User> usersArray;
        private static UserContext dbContext = new UserContext();
        public static List<User> testUsers
        {
            get
            {
                Console.WriteLine(usersArray);
                ResetTestUserData();
                return usersArray;
            }
            set { }
        }

        private static void ResetTestUserData()
        {

            if (usersArray == null)
            {
                usersArray = new List<User>();
                usersArray.Add(new User("kirou", "214htge", "131315111", 4, DateTime.Now, DateTime.Now.AddYears(5)));
                usersArray.Add(new User("falkg", "gfr5g+", "131315021", 4, DateTime.Now, DateTime.Now.AddYears(-3)));
                usersArray.Add(new User("gogodg", "bad221+", "131315003", 1, DateTime.Now, DateTime.Now.AddYears(2)));
            }
        }

        public static User IsUserPassCorrect(string username, string password)
        {
            //User user = (from u in testUsers where u.username.Equals(username) && u.password.Equals(password) select u).FirstOrDefault();
            //return user;

            User user = (from u in dbContext.Users
                         where u.username.Equals(username) &&
                               u.password.Equals(password)
                         select u).FirstOrDefault();
            return user;
        }

        public static void SetUserActiveTo(string username, DateTime activityDate)
        {
            //foreach (User user in testUsers)
            //{
            //    if (user.username.Equals(username))
            //    {
            //        user.isActive = activityDate;
            //        Logger.LogActivity("Activity of " + username + " has been changed.");
            //    }
            //}

            User user = (from u in testUsers
                         where u.username == username
                         select u).First();
            user.isActive = activityDate;
            Logger.LogActivity("Activity of " + username + " has been changed.");
        }

        public static void AssignUserRole(string username, UserRoles role)
        {
            //foreach (User user in testUsers)
            //{
            //    if (user.username.Equals(username))
            //    {
            //        user.userRole = (int)role;
            //        Logger.LogActivity("Role of " + username + " has been changed.");
            //    }
            //}

            UserContext context = new UserContext();
            User user = (from u in testUsers
                        where u.username == username
                        select u).First();
            user.userRole = (int)role;
            context.SaveChanges();
            Logger.LogActivity("Role of " + username + " has been changed.");
        }

        private static bool TestUsersIfEmpty()
        {
            IEnumerable<User> queryStudents = dbContext.Users;
            int countStudents = queryStudents.Count();
            return countStudents == 0;
        }
    }
}
