using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<Tasks> _listTasksToDo;
        public AddTask(ObservableCollection<Tasks> tasks)
        {
            InitializeComponent();
            this.dp_deadline.Text = DateTime.Now.ToShortDateString(); 
            this.tb_note.Text = "One task";
            this._listTasksToDo = tasks;
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
                Users1 = new List<Users>(),
                CreateDate = DateTime.Now,
            };

            DB.AddTask(tasks);
            this._listTasksToDo.Add(tasks);
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
