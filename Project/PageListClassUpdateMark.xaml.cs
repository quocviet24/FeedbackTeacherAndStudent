using Project.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Project
{
    /// <summary>
    /// Interaction logic for PageListClassUpdateMark.xaml
    /// </summary>
    public partial class PageListClassUpdateMark : Page
    {
        private Teacher Teacher = new Teacher();
        private ProjectQnaContext context = new ProjectQnaContext();

        public PageListClassUpdateMark()
        {
            InitializeComponent();
        }

        public PageListClassUpdateMark(Teacher teacher)
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
                            Classname = p.Class.ClassName.ToString(),
                            SubjectName = p.Subject.Name.ToString(),
                        })
                        .Distinct()
                        .ToList();
                dgClass.ItemsSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail to load data: " + ex.Message);
            }
        }

        private void dgClass_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgClass.CurrentItem != null)
            {
                var row = (dynamic)dgClass.CurrentItem;
                string classs = row.Classname.ToString();
                string subjectt = row.SubjectName.ToString();
                var subjectOB = context.Subjects.FirstOrDefault(s => s.Name.Equals(subjectt));
                var classssOB = context.Classroomes.FirstOrDefault(c => c.ClassName.Equals(classs));
                if (subjectOB != null && classssOB != null)
                {
                    // Điều hướng đến PageMarkTeacher với thông tin lớp và môn học tương ứng
                    NavigationService.Navigate(new PageMarkTeacher(Teacher, subjectOB.Id, classssOB.Id));
                }
            }
        }
    }
}
