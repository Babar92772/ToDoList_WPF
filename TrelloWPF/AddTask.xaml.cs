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
using TrelloWPF.Models;

namespace TrelloWPF
{
    /// <summary>
    /// Interaction logic for AddTask.xaml
    /// </summary>
    public partial class AddTask : Window
    {
        private ListView Lv_todo;

        public AddTask(ListView lv_todo)
        {
            InitializeComponent();
            this.Lv_todo = lv_todo;
            this.dp_deadline.Text = DateTime.Now.ToShortDateString();
            this.tb_note.Text = "One task";
        }

        public AddTask(Tasks tasks)
        {
            InitializeComponent();
            this.dp_deadline.Text = tasks.DeadLine.ToShortDateString();
            this.tb_note.Text = tasks.Note;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Tasks tasks = new Tasks
            {
                TaskState = "todo",
                Note = this.tb_note.Text,
                DeadLine = this.dp_deadline.SelectedDate.Value
            };
            Lv_todo.Items.Add(tasks);
            this.Close();
            //MessageBox.Show(tasks.Note + " / " + tasks.TaskState + " / " + tasks.DeadLine);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
