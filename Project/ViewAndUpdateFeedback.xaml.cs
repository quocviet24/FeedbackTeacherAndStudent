using Project.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Project
{
    public partial class ViewAndUpdateFeedback : Window
    {
        private Student student;
        private FeedbacksCurent feedback;
        private ProjectQnaContext context;


        public ViewAndUpdateFeedback()
        {
            InitializeComponent();
        }

        public ViewAndUpdateFeedback(FeedbacksCurent fbc, Student student)
        {
            InitializeComponent();
            this.student = student;
            this.feedback = fbc;
            this.context = new ProjectQnaContext();
            LoadFeedback();
        }

        private void LoadFeedback()
        {
            SelectRadioButtonWithTag(feedback.FreOnTime.ToString(), FreOntime1, FreOntime2, FreOntime3);
            SelectRadioButtonWithTag(feedback.FreFullLession.ToString(), FreFull1, FreFull2, FreFull3);
            SelectRadioButtonWithTag(feedback.FreAns.ToString(), FreResponse1, FreResponse2, FreResponse3);
            comment.Text = feedback.Comment;
        }

        private void SelectRadioButtonWithTag(string tag, params RadioButton[] radioButtons)
        {
            foreach (var radioButton in radioButtons)
            {
                if (radioButton.Tag != null && radioButton.Tag.ToString() == tag)
                {
                    radioButton.IsChecked = true;
                    break;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string freOntimeValue = GetSelectedRadioButtonValue(FreOntime1, FreOntime2, FreOntime3);
            string freFullValue = GetSelectedRadioButtonValue(FreFull1, FreFull2, FreFull3);
            string freResponseValue = GetSelectedRadioButtonValue(FreResponse1, FreResponse2, FreResponse3);

            if (freOntimeValue == null || freFullValue == null || freResponseValue == null)
            {
                MessageBox.Show("One or more attribute have no selection.");
                return;
            }

            FeedbacksCurent feedbacksCurent = context.FeedbacksCurents.FirstOrDefault(x => x.Id == feedback.Id);
            if (feedbacksCurent != null)
            {
                feedbacksCurent.StudentId = student.Id;
                feedbacksCurent.TeacherId = feedback.TeacherId;
                feedbacksCurent.SubjectId = feedback.SubjectId;
                feedbacksCurent.FreOnTime = Int32.Parse(freOntimeValue);
                feedbacksCurent.FreFullLession = Int32.Parse(freFullValue);
                feedbacksCurent.FreAns = Int32.Parse(freResponseValue);
                feedbacksCurent.Comment = comment.Text;
                feedbacksCurent.UpdateFb = true;

                if (context.SaveChanges() > 0)
                {
                    MessageBox.Show("Update feedback success");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Update feedback fail");
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
