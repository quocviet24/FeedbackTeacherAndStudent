using Azure;
using Project.Models;
using System;
using System.Collections.Generic;
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

namespace Project
{
    /// <summary>
    /// Interaction logic for HomeStudent.xaml
    /// </summary>
    public partial class HomeStudent : Window
    {
        private Account accout = new Account();
        public Student Student = new Student();
        private ProjectQnaContext context = new ProjectQnaContext();
        public HomeStudent()
        {
            InitializeComponent();
        }

        public HomeStudent(Project.Models.Account account)
        {
            InitializeComponent();
            this.accout = account;
            var student = context.Students.FirstOrDefault(s => s.Id == account.Id);
            if (student != null)
            {
                this.Student = student;
            }
            this.Title = "Hello " + student.Name;
            ContentFrame.Navigate(new PageProfileStudent(Student));
        }
        public HomeStudent(Student st)
        {
            InitializeComponent();
            this.Student = st;
            this.Title = "Hello " + st.Name;
        }
        private void loadData()
        {
            using (var newContext = new ProjectQnaContext())
            {
                var stUpdate = newContext.Students.FirstOrDefault(s => s.Id == accout.Id);
                if (stUpdate != null)
                {
                    this.Student = stUpdate;
                }
            }
        }

        private void Navigation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            if (listBox.SelectedItem is ListBoxItem selectedItem)
            {
                switch (selectedItem.Content)
                {
                    case "Profile":
                        loadData();
                        ContentFrame.Navigate(new PageProfileStudent(Student));
                        break;
                    case "Classroom":
                        loadData();
                        ContentFrame.Navigate(new PageClassroomStudent(Student));
                        break;
                    case "Show tab":
                        loadData();
                        MainWindow showTab = new MainWindow();
                        showTab.Show();
                        break;
                    case "Logout":
                        MainWindow main = new MainWindow();
                        main.Show();
                        this.Close();
                        break;
                    case "Mark":
                        loadData();
                        ContentFrame.Navigate(new PageMarkStudent(Student));
                        break;
                }
            }
        }
    }
}
