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
            this.RefreshList();    
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Window window_add = new AddTask();
            window_add.ShowDialog();
            RefreshList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (this.lv_todo.SelectedIndex != -1)
            {
                Tasks tasks = this.lv_todo.SelectedItem as Tasks;
                DB.DeleteTask(tasks.ID);
                RefreshList();
                this.lv_todo.Items.Refresh();
            }
            else if(this.lv_inProgress.SelectedIndex != -1)
            {
                RefreshList();
                this.lv_inProgress.Items.Refresh();
            }
            else if (this.lv_done.SelectedIndex != -1)
            {
                RefreshList();
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
                RefreshList();
                this.lv_todo.Items.Refresh();
            }
            else if (this.lv_inProgress.SelectedIndex != -1)
            {
                tasks = this.listTasksInProgress[this.lv_inProgress.SelectedIndex];
                Window window_add = new EditTask(tasks);
                window_add.ShowDialog();
                RefreshList();
                this.lv_inProgress.Items.Refresh();
            }
            else if (this.lv_done.SelectedIndex != -1)
            {
                tasks = this.listTasksDone[this.lv_done.SelectedIndex];
                Window window_add = new EditTask(tasks);
                window_add.ShowDialog();
                RefreshList();
                this.lv_done.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Select a task before editing");
            }
        }

        private void RefreshList()
        {
            this.lv_todo.ItemsSource = null;
            this.lv_inProgress.ItemsSource = null;
            this.lv_done.ItemsSource = null;
            this.allTasks.Clear();
            this.listTasksToDo.Clear();
            this.lv_todo.Items.Clear();
            this.listTasksInProgress.Clear();
            this.lv_inProgress.Items.Clear();
            this.listTasksDone.Clear();
            this.lv_done.Items.Clear();

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
            lv_todo.ItemsSource = listTasksToDo;
            lv_inProgress.ItemsSource = listTasksInProgress;
            lv_done.ItemsSource = listTasksDone;
        }
    }
}