using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class LoginValidation
    {
        private string username;
        private string password;
        private string errorMsg;
        private int errorCode;
        private ActionOnError actionOnError;

        public delegate void ActionOnError(string errorMsg);

        public LoginValidation(string username, string password, ActionOnError actionOnError)
        {
            this.username = username;
            this.password = password;
            this.actionOnError = actionOnError;
        }

        public static UserRoles currentUserRole { get; private set; }
        public static string currentUserUsername { get; private set; }

        public bool ValidateUserInput(ref User user)
        {
            Boolean emptyUserName;
            emptyUserName = username.Equals(String.Empty);

            if (emptyUserName == true)
            {
                errorMsg = "Username not inputted.";
                errorCode = -1;
                actionOnError(errorMsg);
                currentUserRole = UserRoles.ANONYMOUS;
                Logger.LogActivity(errorMsg, errorCode);
                return false;
            }

            Boolean emptyPassword;
            emptyPassword = password.Equals(String.Empty);

            if (emptyPassword == true)
            {
                errorMsg = "Password not inputted.";
                errorCode = -2;
                actionOnError(errorMsg);
                currentUserRole = UserRoles.ANONYMOUS;
                Logger.LogActivity(errorMsg, errorCode);
                return false;
            }

            if (username.Length < 5 || password.Length < 5)
            {
                errorMsg = "Username and password must be at least 5 characters long.";
                errorCode = -3;
                actionOnError(errorMsg);
                currentUserRole = UserRoles.ANONYMOUS;
                Logger.LogActivity(errorMsg, errorCode);
                return false;
            }

            user = UserData.IsUserPassCorrect(username, password);

            if (user == null)
            {
                errorMsg = "No such user exists.";
                errorCode = -4;
                actionOnError(errorMsg);
                currentUserRole = UserRoles.ANONYMOUS;
                Logger.LogActivity(errorMsg, errorCode);
                return false;
            }

            currentUserRole = (UserRoles)user.userRole;
            currentUserUsername = (string)user.username;
            Logger.LogActivity("Successful Login");
            return true;
        }
    }
}
