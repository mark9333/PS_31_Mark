using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int count = 0;

        public List<string> StudStatusChoices { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DisableTextBoxes();
            FillStudStatusChoices();
            this.DataContext = this;
        }

        void ClearAllText()
        {
            textFirstName.Text = string.Empty;
            textMidName.Text = string.Empty;
            textLastName.Text = string.Empty;
            textFaculty.Text = string.Empty;
            textSpecialty.Text = string.Empty;
            textDegree.Text = string.Empty;
            textFacNum.Text = string.Empty;
            textCourse.Text = string.Empty;
            textStream.Text = string.Empty;
            textGroup.Text = string.Empty;
        }

        void DisableTextBoxes()
        {
            textFirstName.IsEnabled = false;
            textMidName.IsEnabled = false;
            textLastName.IsEnabled = false;
            textFaculty.IsEnabled = false;
            textSpecialty.IsEnabled = false;
            textDegree.IsEnabled = false;
            listStatus.IsEnabled = false;
            textFacNum.IsEnabled = false;
            textCourse.IsEnabled = false;
            textStream.IsEnabled = false;
            textGroup.IsEnabled = false;
        }

        public void EnableTextBoxes()
        {
            textFirstName.IsEnabled = true;
            textMidName.IsEnabled = true;
            textLastName.IsEnabled = true;
            textFaculty.IsEnabled = true;
            textSpecialty.IsEnabled = true;
            textDegree.IsEnabled = true;
            listStatus.IsEnabled = true;
            textFacNum.IsEnabled = true;
            textCourse.IsEnabled = true;
            textStream.IsEnabled = true;
            textGroup.IsEnabled = true;
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            EnableTextBoxes();

            List<Student> students = StudentData.getStudents();

            if (count < students.Count)
            {
                ClearAllText();
                textFirstName.Text = students[count].firstName;
                textMidName.Text = students[count].middleName;
                textLastName.Text = students[count].lastName;
                textFaculty.Text = students[count].faculty;
                textSpecialty.Text = students[count].specialty;
                textDegree.Text = students[count].educationDegree;
                //listStatus.Text = students[count].status;
                textFacNum.Text = students[count].facNumber;
                textCourse.Text = students[count].course.ToString();
                textStream.Text = students[count].stream.ToString();
                textGroup.Text = students[count].group.ToString();
                count++;
            }
            else
            {
                count = 0;
                ClearAllText();
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow()
            {
                Height = this.Height,
                Width = this.Width
            };
            loginWindow.Show();
            this.Close();
        }

        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();
            using (IDbConnection connection = new SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery = @"SELECT StatusDescr FROM StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)
                {
                    string s = reader.GetString(0);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }

        public static bool TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<Student> queryStudents = context.Students;
            int countStudents = queryStudents.Count();
            return countStudents == 0;
        }

        private List<Student> getAllStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
            return context.Students.ToList();
        }

        public void CopyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
            foreach (Student student in getAllStudents())
            {
                context.Students.Add(student);
            }
            context.SaveChanges();
        }

        private void btnStudIfEmpty_Click(object sender, RoutedEventArgs e)
        {
            bool isEmpty = TestStudentsIfEmpty();
            if (isEmpty)
            {
                CopyTestStudents();
                System.Windows.MessageBox.Show("successfully added student");
            }
            else
            {
                System.Windows.MessageBox.Show(isEmpty.ToString());
            }
        }
    }
}
