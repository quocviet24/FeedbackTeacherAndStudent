using Project.Models;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
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
using System.Xml.Linq;

namespace Project
{
    /// <summary>
    /// Interaction logic for PageMarkStudent.xaml
    /// </summary>
    public partial class PageMarkStudent : Page
    {
        private Student Student = new Student();
        private ProjectQnaContext context = new ProjectQnaContext();
        public PageMarkStudent()
        {
            InitializeComponent();
        }

        public PageMarkStudent(Student student)
        {
            InitializeComponent();
            this.Student = student;
            loadData();
        }

        private void loadData()
        {
            try
            {
                var data = context.StudentClasses
                        .Select(p => new
                        {
                            ID = p.StudentId,
                            Subject = p.Subject.Name,
                            Class = p.Class.ClassName
                        })
                        .Where(p => p.ID == Student.Id)
                        .ToList();
                dgSubject.ItemsSource = data;
                Name.Text = Student.Name;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail to load data" + ex.Message);
            }
        }

        private void dgSubject_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgSubject.CurrentItem != null)
            {
                // Lấy hàng hiện tại
                var row = (dynamic)dgSubject.CurrentItem;
                string className = row.Class;
                string subject = row.Subject;
                Mark marks = context.Marks.FirstOrDefault(p => p.Class.ClassName.Equals(className) && p.StudentId == Student.Id && p.Subject.Name.Equals(subject));

                if (marks != null)
                {
                    Assignment1.Text = marks.Assignment1.ToString();
                    Assignment2.Text = marks.Assignment2.ToString();
                    ProgressTest1.Text = marks.ProgressTest1.ToString();
                    ProgressTest2.Text = marks.ProgressTest2.ToString();    
                    GroupProject.Text = marks.GroupProject.ToString();  
                    FE.Text = marks.Fe.ToString();
                    PE.Text = marks.Pe.ToString();
                    FER.Text = marks.Fer.ToString();
                }
                else { 
                    reload();
                }
            }
        }

        private void reload()
        {
            Assignment1.Text = "";
            Assignment2.Text = "";
            ProgressTest1.Text = "";
            ProgressTest2.Text = "";
            GroupProject.Text = "";
            FE.Text = "";
            PE.Text = "";
            FER.Text = "";
        }
    }
}
