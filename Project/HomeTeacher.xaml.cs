using Project.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Project
{
    public partial class HomeTeacher : Window
    {
        private Account accout = new Account();
        public Teacher teacher = new Teacher();
        private ProjectQnaContext context = new ProjectQnaContext();

        public HomeTeacher()
        {
            InitializeComponent();
        }

        public HomeTeacher(Account account)
        {
            InitializeComponent();
            this.accout = account;
            var tc = context.Teachers.FirstOrDefault(s => s.IdAccount == account.Id);
            if (tc != null)
            {
                this.teacher = tc;
                this.Title = "Hello " + tc.Name;
            }
            ContentFrame.Navigate(new PageProfileTeacher(teacher));
        }

        public HomeTeacher(Teacher tc)
        {
            InitializeComponent();
            this.teacher = tc;
            this.Title = "Hello " + tc.Name;
        }

        public void UpdateTeacher(Teacher updatedTeacher)
        {
            this.teacher = updatedTeacher;
        }

        private void loadData()
        {
            using (var newContext = new ProjectQnaContext())
            {
                var stUpdate = newContext.Teachers.FirstOrDefault(s => s.Id == teacher.Id);
                if (stUpdate != null)
                {
                    this.teacher = stUpdate;
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
                        ContentFrame.Navigate(new PageProfileTeacher(teacher));
                        break;
                    case "Classroom":
                        loadData();
                        ContentFrame.Navigate(new PageClassroomTeacher(teacher));
                        break;
                    case "Logout":
                        MainWindow main = new MainWindow();
                        main.Show();
                        this.Close();
                        break;
                    case "Mark":
                        loadData();
                        ContentFrame.Navigate(new PageListClassUpdateMark(teacher));
                        break;
                    case "Show tab":
                        loadData();
                        MainWindow showTab = new MainWindow();
                        showTab.Show();
                        break;
                }
            }
        }
    }
}
