using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ExpenseIt
{
    /// <summary>
    /// Interaction logic for ExpenseItHome.xaml
    /// </summary>
    public partial class ExpenseItHome : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string MainCaptionText { get; set; }
        public List<Person> ExpenseDataSource { get; set; }
        public ObservableCollection<string> PersonsChecked { get; set; }
        private DateTime lastChecked;
        public DateTime LastChecked
        {
            get { return lastChecked; }
            set
            {
                lastChecked = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("LastChecked"));
            }
        }

        public ExpenseItHome()
        {
            InitializeComponent();
            MainCaptionText = "View Expense Report:";

            ExpenseDataSource = new List<Person>()
            {
                new Person()
                {
                    Name = "Rose",
                    Department = "Legal",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Lunch", ExpenseAmount=50 },
                        new Expense() { ExpenseType="Transportation", ExpenseAmount=50 }
                    }
                },
                new Person()
                {
                    Name = "Leon",
                    Department = "Marketing",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Document printing", ExpenseAmount=50 },
                        new Expense() { ExpenseType="Gift", ExpenseAmount=125 }
                    }
                },
                new Person()
                {
                    Name="Mary",
                    Department ="Engineering",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Magazine subscription", ExpenseAmount=50 },
                        new Expense() { ExpenseType="New machine", ExpenseAmount=600 },
                        new Expense() { ExpenseType="Software", ExpenseAmount=500 }
                    }
                },
                new Person()
                {
                    Name = "Jesse",
                    Department = "Finance",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Dinner", ExpenseAmount=100 },
                    }
                },
                new Person()
                {
                    Name = "James",
                    Department = "Engineering",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Software", ExpenseAmount=560 },
                    }
                },
                new Person()
                {
                    Name = "David",
                    Department = "Marketing",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Lunch", ExpenseAmount=110 },
                    }
                }
            };

            PersonsChecked = new ObservableCollection<string>();
            LastChecked = DateTime.Now;
            this.DataContext = this;

            peopleListBox.SelectedItem = ExpenseDataSource.ElementAt(4);

            //ListBoxItem james = new ListBoxItem();
            //james.Content = "James";
            //peopleListBox.Items.Add(james);

            //ListBoxItem david = new ListBoxItem();
            //david.Content = "David";
            //peopleListBox.Items.Add(david);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ExpenseReport expenseReport = new ExpenseReport(this.peopleListBox.SelectedItem)
            {
                Height = this.Height,
                Width = this.Width
            };
            expenseReport.ShowDialog();
            this.Close();
        }

        private void peopleListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            LastChecked = DateTime.Now;
            PersonsChecked.Add((peopleListBox.SelectedItem as Person).Name);
        }
    }
}
