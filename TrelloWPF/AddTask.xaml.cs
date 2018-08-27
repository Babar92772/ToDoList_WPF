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
using ToDoListDLL;

namespace TrelloWPF
{
    /// <summary>
    /// Interaction logic for AddTask.xaml
    /// </summary>
    public partial class AddTask : Window
    {
        private List<Tasks> ListTasksToDo;

        public AddTask(List<Tasks> tasks)
        {
            InitializeComponent();
            this.ListTasksToDo = tasks;
            this.dp_deadline.Text = DateTime.Now.ToShortDateString(); 
            this.tb_note.Text = "One task";
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Tasks tasks = new Tasks
            {
                Comments = new List<Comments>(),
                DeadLine = this.dp_deadline.SelectedDate,
                IDUserCreator = Session.CurrentUser.ID,
                Note = this.tb_note.Text,
                TaskState = "todo",
                Users = Session.CurrentUser,
                Users1 = new List<Users>(),
                CreateDate = DateTime.Now,
            };

            DB.AddTask(tasks);
            //Tasks tasks = new Tasks
            //{
            //    TaskState = "todo",
            //    Note = this.tb_note.Text,
            //    DeadLine = this.dp_deadline.SelectedDate.Value,
            //    CreateDate = DateTime.Now
            //};
            //ListTasksToDo.Add(tasks);
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
