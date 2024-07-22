using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Project
{
    /// <summary>
    /// Interaction logic for PageProfileStudent.xaml
    /// </summary>
    public partial class PageProfileStudent : Page
    {
        private Student student = new Student();
        private ProjectQnaContext context = new ProjectQnaContext();
        public PageProfileStudent()
        {
            InitializeComponent();
        }

        public PageProfileStudent(Student st)
        {
            InitializeComponent();
            this.student = st;
            loadData();
        }

        private void loadData()
        {
            try
            {
                if (student != null)
                {
                    Mojor major = context.Mojors.FirstOrDefault(p => p.Id == student.MojorId);

                    if (student != null && major != null)
                    {
                        name.Text = student.Name;
                        txtName.Text = student.Name;
                        txtId.Text = student.Id.ToString();
                        txtDob.Text = student.Dob.ToString();
                        txtAdress.Text = student.Adress;
                        txtEmail.Text = student.Email;
                        txtMajor.Text = major.Name;
                        txtGender.Text = student.Gender.HasValue ? (student.Gender.Value ? "Girl" : "Boy") : "Unknown";
                        txtPhone.Text = student.Phone;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail to load data: " + ex.Message);
            }
        }

        private void btnupdate_Click(object sender, RoutedEventArgs e)
        {
            string error = checkError();
            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error);
                loadData();
                return;
            }
            else
            {
                int id;
                if (Int32.TryParse(txtId.Text, out id))
                {
                    var stUpdate = context.Students.FirstOrDefault(x => x.Id == id);
                    if (stUpdate != null)
                    {
                        stUpdate.Adress = txtAdress.Text;
                        stUpdate.Dob = DateOnly.Parse(txtDob.Text); 
                        stUpdate.Phone = txtPhone.Text;
                        stUpdate.Email = txtEmail.Text;

                        if (context.SaveChanges() > 0)
                        {
                            MessageBox.Show("Update success");
                            this.student = stUpdate;
                            loadData();
                        }
                        else
                        {
                            MessageBox.Show("Update fail");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid data. Please check the fields.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid ID. Please check the ID field.");
                }
            }
        }

        private string checkError()
        {
            string error = "";
            if (string.IsNullOrEmpty(txtAdress.Text))
            {
                error += "The adress cannot null!\n";
            }
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                error += "The phone number cannot null!\n";
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                error += "The email cannot null!\n";
            }
            else
            {
                // Regular expression for validating an email
                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

                if (!Regex.IsMatch(txtEmail.Text, emailPattern))
                {
                    error += "The email format is invalid!\n";
                }
            }
            if (txtPhone.Text.Length != 10 || !txtPhone.Text.All(char.IsDigit))
            {
                error += "The phone number must be exactly 10 digits!\n";
            }
            return error;
        }

        private void reset()
        {
            txtName.Text = "";
            txtId.Text = "";
            txtDob.SelectedDate = null;
            txtAdress.Text = "";
            txtEmail.Text = "";
            txtMajor.Text = "";
            txtGender.Text = "";
            txtPhone.Text = "";
        }

    }
}
