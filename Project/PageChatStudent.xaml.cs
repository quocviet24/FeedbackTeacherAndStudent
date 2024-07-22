using Project.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Project
{
    public partial class PageChatStudent : Page
    {
        private Teacher Teacher;
        private Student student;
        private ProjectQnaContext context = new ProjectQnaContext();
        private ObservableCollection<MessageShow> messages;
        private string rolee = "";
        private string className = "";
        private string subject = "";
        private DispatcherTimer timer;

        public ObservableCollection<MessageShow> Messages
        {
            get { return messages; }
            set { messages = value; }
        }

        public PageChatStudent()
        {
            InitializeComponent();
            DataContext = this;
            Messages = new ObservableCollection<MessageShow>();
            LoadMessages();
        }

        public PageChatStudent(Teacher Teacher, Student student, string rolee)
        {
            InitializeComponent();
            DataContext = this;
            this.rolee = rolee;
            this.Teacher = Teacher;
            this.student = student;
            Messages = new ObservableCollection<MessageShow>();
            LoadMessages();
            // Khởi tạo và cấu hình DispatcherTimer
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5); // Thiết lập khoảng thời gian là 5 giây
            timer.Tick += Timer_Tick;
            timer.Start(); // Bắt đầu đếm thời gian
        }
        public PageChatStudent(Teacher Teacher, Student student, string rolee, string className, string subject)
        {
            InitializeComponent();
            DataContext = this;
            this.rolee = rolee;
            this.subject = subject;
            this.className = className;
            this.Teacher = Teacher;
            this.student = student;
            Messages = new ObservableCollection<MessageShow>();
            LoadMessages();
            // Khởi tạo và cấu hình DispatcherTimer
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5); // Thiết lập khoảng thời gian là 5 giây
            timer.Tick += Timer_Tick;
            timer.Start(); // Bắt đầu đếm thời gian
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Đây là hàm được gọi sau mỗi 5 giây
            LoadMessages();
        }

        private void LoadMessages()
        {
            try
            {
                var data = context.MessagesChats
                    .Where(p => p.TeacherId == Teacher.Id && p.StudentId == student.Id)
                    .Select(p => new MessageShow
                    {
                        Content = p.MessageContent,
                        Timestamp = p.Timestamp.HasValue ? p.Timestamp.Value : DateTime.MinValue,
                        SenderRole = p.Sender
                    })
                    .ToList();

                Messages.Clear(); // Xóa tất cả các tin nhắn hiện tại
                foreach (var message in data)
                {
                    Messages.Add(message); // Thêm tin nhắn mới vào ObservableCollection
                }

                // Cuộn xuống dòng mới nhất
                if (ChatListView.Items.Count > 0)
                {
                    var lastItem = ChatListView.Items[ChatListView.Items.Count - 1];
                    ChatListView.ScrollIntoView(lastItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail to load data: " + ex.Message);
            }
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(chat.Text))
            {
                if (!string.IsNullOrEmpty(rolee))
                {
                    MessagesChat messchat = new MessagesChat()
                    {
                        StudentId = student.Id,
                        TeacherId = Teacher.Id,
                        MessageContent = chat.Text,
                        Timestamp = DateTime.Now,
                        Sender = rolee,
                        IsRead = true
                    };
                    context.MessagesChats.Add(messchat);
                    if (context.SaveChanges() > 0)
                    {
                        LoadMessages(); // Tải lại tin nhắn sau khi gửi thành công
                        chat.Text = ""; // Xóa nội dung trong ô chat
                    }
                    else
                    {
                        MessageBox.Show("Send fail");
                    }
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (rolee.Equals("student"))
            {
                ContentFrameChat.Navigate(new PageClassroomStudent(student));
            }else if (rolee.Equals("teacher"))
            {
                ContentFrameChat.Navigate(new PageListStudentTeacher(className, subject, Teacher));
            }

        }
    }

    public class MessageShow
    {
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public string SenderRole { get; set; } // "Student" or "Teacher"
    }

    public class MessageTemplateSelector : DataTemplateSelector
    {
        public DataTemplate StudentTemplate { get; set; }
        public DataTemplate TeacherTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var message = item as MessageShow;
            if (message == null)
                return base.SelectTemplate(item, container);

            return message.SenderRole == "student" ? StudentTemplate : TeacherTemplate;
        }
    }
}
