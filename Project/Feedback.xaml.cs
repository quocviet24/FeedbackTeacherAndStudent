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
using System.Windows.Shapes;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Project
{
    /// <summary>
    /// Interaction logic for Feedback.xaml
    /// </summary>
    public partial class Feedback : Window
    {
        Teacher teacher = new Teacher();
        Subject subject = new Subject();
        Student student = new Student();
        Classroome classroom = new Classroome();
        private ProjectQnaContext context = new ProjectQnaContext();
        public Feedback()
        {
            InitializeComponent();
        }

        public Feedback(Classroome cl ,Teacher teacher, Subject subject, Student student)
        {
            InitializeComponent();
            this.teacher = teacher;
            this.subject = subject;
            this.student = student;
            this.classroom = cl;
            this.Title = "hello" + classroom.Id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // FreOntime group
            string freOntimeValue = GetSelectedRadioButtonValue(FreOntime1, FreOntime2, FreOntime3);
            // FreFull group
            string freFullValue = GetSelectedRadioButtonValue(FreFull1, FreFull2, FreFull3);
            // FreResponse group
            string freResponseValue = GetSelectedRadioButtonValue(FreResponse1, FreResponse2, FreResponse3);

            if (freOntimeValue == null || freFullValue == null || freResponseValue == null)
            {
                MessageBox.Show("One or more attribute have no selection.");
            }
            else
            {
                FeedbacksCurent fbc = new FeedbacksCurent()
                {
                    StudentId = student.Id,
                    TeacherId = teacher.Id,
                    SubjectId = subject.Id,
                    ClassId = classroom.Id,
                    FreOnTime = Int32.Parse(freOntimeValue),
                    FreFullLession = Int32.Parse(freFullValue),
                    FreAns = Int32.Parse(freResponseValue),
                    Comment = comment.Text,
                    UpdateFb = false
                };

                context.FeedbacksCurents.Add(fbc);
                if (context.SaveChanges() > 0)
                {
                    System.Windows.MessageBox.Show("Feedback success");
                }
                else
                {
                    System.Windows.MessageBox.Show("Feedback fail");
                }
            }
        }

        private string GetSelectedRadioButtonValue(params RadioButton[] radioButtons)
        {
            foreach (var radioButton in radioButtons)
            {
                if (radioButton.IsChecked == true)
                {
                    return radioButton.Tag.ToString();
                }
            }
            return null;
        }
    }
}
