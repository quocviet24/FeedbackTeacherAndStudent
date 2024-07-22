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
    /// Interaction logic for PageClassroomStudent.xaml
    /// </summary>
    public partial class PageClassroomStudent : Page
    {
        private Student student = new Student();
        private ProjectQnaContext context = new ProjectQnaContext();
        public PageClassroomStudent()
        {
            InitializeComponent();
        }

        public PageClassroomStudent(Student student )
        {
            InitializeComponent();
            this.student = student;
            loadData();
        }

        private void loadData()
        {
            try
            {
                var data = context.StudentClasses
                        .Select(p => new
                        {
                            Id = p.StudentId,
                            Class = p.Class.ClassName,
                            Subject = p.Subject.Name,
                            Teacher = p.Teacher.Name
                        })
                        .Where(p => p.Id == student.Id)
                        .ToList();
                dgClass.ItemsSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail to load data" + ex.Message);
            }
        }

        private void dgClass_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgClass.CurrentItem != null)
            {
                // Lấy hàng hiện tại
                var row = (dynamic)dgClass.CurrentItem;

                // Hiển thị thông tin của hàng
                txtName.Text = row.Class;
                txtSubject.Text = row.Subject;
                txtLecturer.Text = row.Teacher;
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtName.Text = "";
            txtSubject.Text = "";
            txtLecturer.Text = "";
        }

        private void fbLecturer_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSubject.Text))
            {
                MessageBox.Show("You have to choose a lecturer to feedback");
            }
            else
            {
                string subject = txtSubject.Text;
                string lecturer = txtLecturer.Text;
                string classroom = txtName.Text;
                var s = context.Subjects.FirstOrDefault(u => u.Name.Equals(subject));
                var l = context.Teachers.FirstOrDefault(u => u.Name.Equals(lecturer));
                var c = context.Classroomes.FirstOrDefault(c => c.ClassName.Equals(classroom));

                var feedbackCurren = context.FeedbacksCurents.FirstOrDefault(f => f.Subject.Name.Equals(subject) && f.StudentId == student.Id && f.Teacher.Name.Equals(lecturer) && f.Class.ClassName.Equals(classroom));

                if (feedbackCurren != null)
                {
                    if (feedbackCurren.UpdateFb == true)
                    {
                        MessageBox.Show("bạn đã update feedback giảng viên này 1 lần rồi");
                        return;
                    }
                    MessageBoxResult result = MessageBox.Show(
                "You have already provided feedback for this teacher in this subject.\nWould you like to see that feedback?",
                "Feedback Confirmation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        ViewAndUpdateFeedback vnu = new ViewAndUpdateFeedback(feedbackCurren, student);
                        vnu.Show();
                    }
                }
                else
                {
                    Feedback fbCurent = new Feedback(c, l, s, student);
                    fbCurent.Show();
                }

            }
        }

        private void qnalecturer_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSubject.Text))
            {
                MessageBox.Show("You have to choose a lecturer to ask");
            }
            string lecturer = txtLecturer.Text;
            Teacher teacher = context.Teachers.FirstOrDefault(u => u.Name.Equals(lecturer));
            if(teacher != null)
            {
                ContentFrame.Navigate(new PageChatStudent(teacher, student, "student"));
            }
        }
    }
}
