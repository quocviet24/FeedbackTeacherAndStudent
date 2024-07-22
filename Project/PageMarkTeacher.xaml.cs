using Project.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Project
{
    /// <summary>
    /// Interaction logic for PageMarkTeacher.xaml
    /// </summary>
    public partial class PageMarkTeacher : Page
    {
        Teacher teacher = new Teacher();
        private ProjectQnaContext context = new ProjectQnaContext();

        public PageMarkTeacher()
        {
            InitializeComponent();
        }

        public PageMarkTeacher(Teacher teacher, int subjectID, int classID)
        {
            InitializeComponent();
            this.teacher = teacher;
            loadData(subjectID, classID);
        }

        private void loadData(int subjectId, int classID)
        {
            try
            {
                var data = context.Marks
                       .Where(p => p.SubjectId == subjectId && p.ClassId == classID)
                        .Select(p => new
                        {
                            ID = p.StudentId,
                            Name = p.Student.Name,
                            Class = p.Class.ClassName,
                            Subject = p.Subject.Name,
                            Assignment1 = p.Assignment1,
                            Assignment2 = p.Assignment2,
                            ProgressTest1 = p.ProgressTest1,
                            ProgressTest2 = p.ProgressTest2,
                            GroupProject = p.GroupProject,
                            PE = p.Pe,
                            FE = p.Fe,
                            FER = p.Fer
                        })
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
                // Lấy hàng hiện tại
                var row = (dynamic)dgClass.CurrentItem;

                // Hiển thị thông tin của hàng
                idd.Text = row.ID.ToString();
                classsroom.Text = row.Class.ToString();
                subjectt.Text = row.Subject.ToString();
                if (row.Assignment1 != null)
                {
                    ass1.Text = row.Assignment1.ToString();
                }
                if (row.Assignment2 != null)
                {
                    ass2.Text = row.Assignment2.ToString();
                }
                if (row.ProgressTest1 != null)
                {
                    pgr1.Text = row.ProgressTest1.ToString();
                }
                if (row.ProgressTest2 != null)
                {
                    pgr2.Text = row.ProgressTest2.ToString();
                }
                if (row.GroupProject != null)
                {
                    GroupProject.Text = row.GroupProject.ToString();
                }
                if (row.PE != null)
                {
                    PE.Text = row.PE.ToString();
                }
                if (row.FE != null)
                {
                    FE.Text = row.FE.ToString();
                }
                if (row.FER != null)
                {
                    FER.Text = row.FER.ToString();
                }
            }
        }

        private void btnFb_Click(object sender, RoutedEventArgs e)
        {
            int id;
            if (Int32.TryParse(idd.Text, out id))
            {
                var subject = context.Subjects.FirstOrDefault(s => s.Name.Equals(subjectt.Text));
                var classss = context.Classroomes.FirstOrDefault(c => c.ClassName.Equals(classsroom.Text));
                if (subject != null && classss != null)
                {
                    var stUpdate = context.Marks.FirstOrDefault(x => x.StudentId == id && x.ClassId == classss.Id && x.SubjectId == subject.Id);
                    if (stUpdate != null)
                    {
                        double result;

                        if (double.TryParse(ass1.Text, out result))
                        {
                            stUpdate.Assignment1 = result;
                        }
                        if (double.TryParse(ass2.Text, out result))
                        {
                            stUpdate.Assignment2 = result;
                        }
                        if (double.TryParse(pgr1.Text, out result))
                        {
                            stUpdate.ProgressTest1 = result;
                        }
                        if (double.TryParse(pgr2.Text, out result))
                        {
                            stUpdate.ProgressTest2 = result;
                        }
                        if (double.TryParse(GroupProject.Text, out result))
                        {
                            stUpdate.GroupProject = result;
                        }
                        if (double.TryParse(PE.Text, out result))
                        {
                            stUpdate.Pe = result;
                        }
                        if (double.TryParse(FE.Text, out result))
                        {
                            stUpdate.Fe = result;
                        }
                        if (double.TryParse(FER.Text, out result))
                        {
                            stUpdate.Fer = result;
                        }

                        if (context.SaveChanges() > 0)
                        {
                            MessageBox.Show("Update success");
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
            }
            else
            {
                MessageBox.Show("Invalid ID. Please check the ID field.");
            }
        }
    }
}
