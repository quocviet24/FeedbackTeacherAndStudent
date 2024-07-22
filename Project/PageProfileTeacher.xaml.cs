using Project.Models;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Project
{
    public partial class PageProfileTeacher : Page
    {
        private Teacher Teacher = new Teacher();
        private ProjectQnaContext context = new ProjectQnaContext();

        public PageProfileTeacher()
        {
            InitializeComponent();
        }

        public PageProfileTeacher(Teacher tc)
        {
            InitializeComponent();
            this.Teacher = tc;
            loadData();
        }

        private void loadData()
        {
            try
            {
                if (Teacher != null)
                {
                    name.Text = Teacher.Name;
                    txtName.Text = Teacher.Name;
                    txtId.Text = Teacher.Id.ToString();
                    txtDob.Text = Teacher.Dob.ToString();
                    txtAdress.Text = Teacher.Adress;
                    txtEmail.Text = Teacher.Email;
                    txtExp.Text = Teacher.NumberExp.ToString();
                    txtGender.Text = Teacher.Gender.HasValue ? (Teacher.Gender.Value ? "Girl" : "Boy") : "Unknown";
                    txtPhone.Text = Teacher.Phone;
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
                loadData();
                MessageBox.Show(error);
                return;
            }
            else
            {
                int id;
                if (Int32.TryParse(txtId.Text, out id))
                {
                    var stUpdate = context.Teachers.FirstOrDefault(x => x.Id == id);
                    if (stUpdate != null)
                    {
                        stUpdate.Adress = txtAdress.Text;
                        stUpdate.Dob = DateOnly.Parse(txtDob.Text);
                        stUpdate.Phone = txtPhone.Text;
                        stUpdate.Email = txtEmail.Text;

                        if (context.SaveChanges() > 0)
                        {
                            MessageBox.Show("Update sucess");
                            this.Teacher = stUpdate;
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
            }else
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
    }
}
