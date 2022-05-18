using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPFExample
{
    public class InfoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MessageBox.Show("Oi Josuke, I used [Za Hando] to erase this message. Ain't that wacky?!");
            NamesWindow namesWindow = new NamesWindow();
            namesWindow.Show();
        }
    }
}
