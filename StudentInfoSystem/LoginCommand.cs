using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentInfoSystem
{
    public class LoginCommand : ICommand
    {
        public void Execute(object parameter)
        {
            Student student;
            LoginWindow logWindow = new LoginWindow();
            var login = parameter as Login;
            student = StudentData.IsUserPassCorrect(login.Username, login.Password);

            if (student != null)
            {
                logWindow.CreateMainWindow(student);
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}