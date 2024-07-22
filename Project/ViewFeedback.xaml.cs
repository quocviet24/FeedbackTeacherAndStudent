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
using System.Windows.Shapes;

namespace Project
{
    /// <summary>
    /// Interaction logic for ViewFeedback.xaml
    /// </summary>
    public partial class ViewFeedback : Window
    {
        private Teacher Teacher = new Teacher();
        private ProjectQnaContext context = new ProjectQnaContext();
        public ViewFeedback()
        {
            InitializeComponent();
        }

        public ViewFeedback(int classId, int subjectId, Teacher teacher)
        {
            InitializeComponent();
            this.Teacher = teacher;
            loadData(classId, subjectId);
        }

        private void loadData(int classId, int subjectID)
        {
            try
            {
                var comment = context.FeedbacksCurents
                        .Where(p => p.TeacherId == Teacher.Id && p.SubjectId == subjectID && p.ClassId == classId)
                        .Select(p => new
                        {
                            Comment = p.Comment
                        })
                        .ToList();
                dgClass.ItemsSource = comment;

                var fre = context.FeedbacksCurents
                        .Where(p => p.TeacherId == Teacher.Id && p.SubjectId == subjectID && p.ClassId == classId)
                        .Select(p => new
                        {
                            freOntime = p.FreOnTime,
                            freFull = p.FreFullLession,
                            freRespone = p.FreFullLession
                        })
                        .ToList();
                if(fre.Count > 0 ) {
                    int fot = 0;
                    int ff = 0;
                    int frs = 0;
                    foreach (var item in fre)
                    {
                        if (item.freOntime == 1)
                        {
                            fot += 100;
                        }
                        else if (item.freOntime == 2)
                        {
                            fot += 50;
                        }
                        else
                        {
                            fot += 0;
                        }

                        // *****************

                        if (item.freFull == 1)
                        {
                            ff += 100;
                        }
                        else if (item.freFull == 2)
                        {
                            ff += 50;
                        }
                        else
                        {
                            ff += 0;
                        }

                        //*******************

                        if (item.freRespone == 1)
                        {
                            frs += 100;
                        }
                        else if (item.freRespone == 2)
                        {
                            frs += 50;
                        }
                        else
                        {
                            frs += 0;
                        }
                    }

                    //**** chuyển đổi sang phần trăm
                    fot = fot / fre.Count;
                    ff = ff / fre.Count;
                    frs = frs / fre.Count;

                    freOntime.Text = fot.ToString() + "%";
                    freFull.Text = ff.ToString() + "%";
                    freRespone.Text = frs.ToString() + "%";
                }
                else
                {
                    MessageBox.Show("There are no feedback");
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail to load data: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
