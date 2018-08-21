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
    /// Interaction logic for ToDoList.xaml
    /// </summary>
    public partial class ToDoList : Window
    {
        public ToDoList()
        {
            InitializeComponent();
            List<Tasks> listTasksToDo = new List<Tasks>();
            List<Tasks> listTasksInProgress = new List<Tasks>();
            List<Tasks> listTasksDone = new List<Tasks>();

            //Tasks tasks = new Tasks();
            //tasks.DeadLine = DateTime.Now;
            //tasks.Note = "testnote";
            //listTasks.Add(tasks);
            //lv_inProgress.ItemsSource = listTasks;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Window window_add = new AddTask(this.lv_todo);
            window_add.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (this.lv_todo.SelectedIndex != -1)
            {
                this.lv_todo.Items.Remove(this.lv_todo.SelectedItem);
            }
            else if(this.lv_inProgress.SelectedIndex != -1)
            {
                this.lv_inProgress.Items.Remove(this.lv_inProgress.SelectedItem);
            }
            else if (this.lv_done.SelectedIndex != -1)
            {
                this.lv_done.Items.Remove(this.lv_done.SelectedItem);
            }
            else
            {
                MessageBox.Show("Select a task before deleting");
            }     
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Tasks tasks;
            if (this.lv_todo.SelectedIndex != -1)
            {
                tasks = this.lv_todo.SelectedItem as Tasks;
                Window window_add = new EditTask(tasks);
                window_add.ShowDialog();
                this.lv_todo.Items.Refresh();
            }
            else if (this.lv_inProgress.SelectedIndex != -1)
            {
                tasks = this.lv_inProgress.SelectedItem as Tasks;
                Window window_add = new EditTask(tasks);
                window_add.ShowDialog();
                this.lv_inProgress.Items.Refresh();
            }
            else if (this.lv_done.SelectedIndex != -1)
            {
                tasks = this.lv_done.SelectedItem as Tasks;
                Window window_add = new EditTask(tasks);
                window_add.ShowDialog();
                this.lv_done.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Select a task before editing");
            }
        }
    }
}
