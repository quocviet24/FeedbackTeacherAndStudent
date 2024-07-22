using Project.Models;
using Project.Service;
using System.Security.Principal;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProjectQnaContext context = new ProjectQnaContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            try
            {
                var user = context.Accounts
                    .FirstOrDefault(u => u.Username.Equals(username) && u.Password.Equals(password));

                if (user != null)
                {
                    if(user.RoleId == 1)
                    {
                        HomeStudent home = new HomeStudent(user);
                        home.Show();
                        this.Close();
                    }
                    else if (user.RoleId == 2)
                    {
                        HomeTeacher tc = new HomeTeacher(user);
                        tc.Show(); 
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}