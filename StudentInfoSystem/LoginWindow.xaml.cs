using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = new Login();
        }

        //private void btnLogin_Click(object sender, RoutedEventArgs e)
        //{
        //    Student student;
        //    string username = textUsername.Text;
        //    string password = textPassword.Text;

        //    student = StudentData.IsUserPassCorrect(username, password);

        //    if (student != null)
        //    {
        //        MainWindow mainWindow = new MainWindow()
        //        {
        //            Height = this.Height,
        //            Width = this.Width

        //        };
        //        mainWindow.EnableTextBoxes();
        //        FillTextFields(mainWindow, student);
        //        mainWindow.lblTestMsg.Visibility = Visibility.Hidden;
        //        mainWindow.btnTest.Visibility = Visibility.Hidden;
        //        mainWindow.Show();
        //        this.Close();
        //    }

        //}

        private void FillTextFields(MainWindow mainWindow, Student student)
        {
            mainWindow.textFirstName.Text = student.firstName;
            mainWindow.textMidName.Text = student.middleName;
            mainWindow.textLastName.Text = student.lastName;
            mainWindow.textFaculty.Text = student.faculty;
            mainWindow.textSpecialty.Text = student.specialty;
            mainWindow.textDegree.Text = student.educationDegree;
            //mainWindow.textStatus.Text = student.status;
            mainWindow.textFacNum.Text = student.facNumber;
            mainWindow.textCourse.Text = student.course.ToString();
            mainWindow.textStream.Text = student.stream.ToString();
            mainWindow.textGroup.Text = student.group.ToString();
        }

        public void CreateMainWindow(Student student)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.EnableTextBoxes();
            FillTextFields(mainWindow, student);
            mainWindow.lblTestMsg.Visibility = Visibility.Hidden;
            mainWindow.btnTest.Visibility = Visibility.Hidden;
            mainWindow.Show();
            this.Close();
        }
    }
}
