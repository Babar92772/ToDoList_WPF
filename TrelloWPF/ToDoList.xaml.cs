using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
    /// Interaction logic for ToDoList.xaml
    /// </summary>
    public partial class ToDoList : Window
    {
        private List<Tasks> allTasks = new List<Tasks>();
        private List<Tasks> listTasksToDo = new List<Tasks>();
        private List<Tasks> listTasksInProgress = new List<Tasks>();
        private List<Tasks> listTasksDone = new List<Tasks>();

        public ToDoList()
        {
            InitializeComponent();
            RefreshList();
            lv_todo.ItemsSource = listTasksToDo;
            lv_inProgress.ItemsSource = listTasksInProgress;
            lv_done.ItemsSource = listTasksDone;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Window window_add = new AddTask(listTasksToDo);
            window_add.ShowDialog();
            RefreshList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (this.lv_todo.SelectedIndex != -1)
            {
                this.listTasksToDo.RemoveAt(this.lv_todo.SelectedIndex);
                this.lv_todo.Items.Refresh();
            }
            else if(this.lv_inProgress.SelectedIndex != -1)
            {
                this.listTasksInProgress.RemoveAt(this.lv_inProgress.SelectedIndex);
                this.lv_inProgress.Items.Refresh();
            }
            else if (this.lv_done.SelectedIndex != -1)
            {
                this.listTasksDone.RemoveAt(this.lv_done.SelectedIndex);
                this.lv_done.Items.Refresh();
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
                tasks = this.listTasksToDo[this.lv_todo.SelectedIndex];
                Window window_add = new EditTask(tasks);
                window_add.ShowDialog();
                this.lv_todo.Items.Refresh();
            }
            else if (this.lv_inProgress.SelectedIndex != -1)
            {
                tasks = this.listTasksInProgress[this.lv_inProgress.SelectedIndex];
                Window window_add = new EditTask(tasks);
                window_add.ShowDialog();
                this.lv_inProgress.Items.Refresh();
            }
            else if (this.lv_done.SelectedIndex != -1)
            {
                tasks = this.listTasksDone[this.lv_done.SelectedIndex];
                Window window_add = new EditTask(tasks);
                window_add.ShowDialog();
                this.lv_done.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Select a task before editing");
            }
        }

        private void RefreshList()
        {
            allTasks = DB.GetTasks().ToList();
            foreach (Tasks tasks in allTasks)
            {
                if (Session.CurrentUser.ID == tasks.IDUserCreator)
                {   
                    if (tasks.TaskState == "todo")
                    {
                        this.listTasksToDo.Add(tasks);
                    }
                    else if (tasks.TaskState == "progress")
                    {
                        this.listTasksInProgress.Add(tasks);
                    }
                    else if (tasks.TaskState == "done")
                    {
                        this.listTasksDone.Add(tasks);
                    }
                }
            }
        }
    }
}