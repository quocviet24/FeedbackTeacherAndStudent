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

namespace Project
{
    /// <summary>
    /// Interaction logic for PageClassroomTeacher.xaml
    /// </summary>
    public partial class PageClassroomTeacher : Page
    {
        private Teacher Teacher = new Teacher();
        private ProjectQnaContext context = new ProjectQnaContext();
        public PageClassroomTeacher()
        {
            InitializeComponent();
        }
        public PageClassroomTeacher(Teacher teacher)
        {
            InitializeComponent();
            this.Teacher = teacher;
            loadData();
        }
        private void loadData()
        {
            try
            {
                var data = context.StudentClasses
                        .Where(p => p.TeacherId == Teacher.Id)
                        .Select(p => new
                        {
                            Id = p.TeacherId,
                            Class = p.Class.ClassName,
                            Subject = p.Subject.Name
                        })
                        .Distinct() // Loại bỏ các giá trị trùng lặp
                        .ToList();
                dgClass.ItemsSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail to load data: " + ex.Message);
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtName.Text = "";
            txtSubject.Text = "";
        }

        private void dgClass_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgClass.CurrentItem != null)
            {
                ContentFrame.Navigate(null);
                // Lấy hàng hiện tại
                var row = (dynamic)dgClass.CurrentItem;

                // Hiển thị thông tin của hàng
                txtName.Text = row.Class;
                txtSubject.Text = row.Subject;

                // Kiểm tra null hoặc chuỗi rỗng
                if (string.IsNullOrEmpty(txtSubject.Text) || string.IsNullOrEmpty(txtName.Text))
                {
                    MessageBox.Show("Subject or Class name cannot be empty.");
                    return;
                }
            }
        }
        private void btnFb_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSubject.Text) || string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Subject or Class name cannot be empty.");
                return;
            }
            var subject = context.Subjects.FirstOrDefault(p => p.Name.Equals(txtSubject.Text));
            var classRoom = context.Classroomes.FirstOrDefault(c => c.ClassName.Equals(txtName.Text));
            if (subject != null && classRoom != null)
            {
                ContentFrame.Navigate(new PageFeedbackTeacher(classRoom.Id, subject.Id, Teacher));
            }
        }

        private void viewListStd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSubject.Text) || string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Subject or Class name cannot be empty.");
                return;
            }
            else
            {
                ContentFrame.Navigate(new PageListStudentTeacher(txtName.Text, txtSubject.Text, Teacher));
            }
        }
    }
}

