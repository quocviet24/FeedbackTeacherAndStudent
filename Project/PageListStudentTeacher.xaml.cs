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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Project
{
    /// <summary>
    /// Interaction logic for PageListStudentTeacher.xaml
    /// </summary>
    public partial class PageListStudentTeacher : Page
    {
        private Teacher Teacher = new Teacher();
        private ProjectQnaContext context = new ProjectQnaContext();
        private string className = "";
        private string subject = "";
        public PageListStudentTeacher()
        {
            InitializeComponent();
        }
        public PageListStudentTeacher(string className, string subject, Teacher teacher)
        {
            InitializeComponent();
            this.className = className;
            this.subject = subject;
            this.Teacher = teacher;
            loadData(className, subject);
            this.Title = "List of " + subject + "students in the class" + className;
        }
        private void loadData(string classname, string subject)
        {
            try
            {
                var data = context.StudentClasses
                    .Where(p => p.TeacherId == Teacher.Id
                                && p.Subject.Name.Equals(subject)
                                && p.Class.ClassName.Equals(classname))
                    .Select(p => new
                    {
                        Id = p.StudentId,
                        Name = p.Student.Name,
                        DateofBirth = p.Student.Dob.ToString(),
                        NewMessageIndicator = context.MessagesChats
                            .Where(m => m.TeacherId == Teacher.Id && m.StudentId == p.StudentId)
                            .OrderByDescending(m => m.Timestamp)
                            .Select(m => m.IsRead == true ? "New mess" : string.Empty)
                            .FirstOrDefault()
                    })
                    .ToList();

                dgClass.ItemsSource = data;
            }
            catch (Exception ex)
            {
                // Handle exception
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private void dgClass_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgClass.CurrentItem != null)
            {
                // Lấy hàng hiện tại
                var row = (dynamic)dgClass.CurrentItem;
                int id = Convert.ToInt32(row.Id);
                Student student = context.Students.FirstOrDefault(p => p.Id == id);

                Mojor major = context.Mojors.FirstOrDefault(p => p.Id == student.MojorId);

                if (student != null && major != null)
                {
                    // Hiển thị thông tin của hàng
                    txtName.Text = student.Name;
                    txtId.Text = student.Id.ToString();
                    txtDob.Text = row.DateofBirth;
                    txtAdress.Text = student.Adress;
                    txtEmail.Text = student.Email;
                    txtMajor.Text = major.Name;
                    txtGender.Text = student.Gender.HasValue ? (student.Gender.Value ? "Girl" : "Boy") : "Unknown";
                    txtPhone.Text = student.Phone;
                }
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtName.Text = "";
            txtId.Text = "";
            txtDob.Text = "";
            txtAdress.Text = "";
            txtEmail.Text = "";
            txtMajor.Text = "";
            txtGender.Text = "";
            txtPhone.Text = "";
        }

        private void fb_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("You have to choose a lecturer to ask");
            }
            Student st = context.Students.FirstOrDefault(s => s.Id == Int32.Parse(txtId.Text));
            MessagesChat ms = context.MessagesChats
        .Where(s => s.TeacherId == Teacher.Id && s.StudentId == st.Id)
        .OrderByDescending(s => s.Timestamp)
        .FirstOrDefault();


            if (ms != null)
            {
                ms.IsRead = false;
                if (context.SaveChanges() > 0)
                {
                    MessageBox.Show("Update sucess");
                }
                else
                {
                    MessageBox.Show("Update fail");
                }
            }

            if (Teacher != null)
            {
                ContentFrameChatTc.Navigate(new PageChatStudent(Teacher, st, "teacher", className, subject));
            }
        }
    }
}
