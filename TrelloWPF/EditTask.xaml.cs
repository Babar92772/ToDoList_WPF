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
    /// Interaction logic for EditTask.xaml
    /// </summary>
    public partial class EditTask : Window
    {
        public Tasks tasks;
        private ObservableCollection<Tasks> _OCTasks;
        private int _position;

        public EditTask(Tasks tasks, ObservableCollection<Tasks> OCtasks)
        {
            InitializeComponent();
            this.tasks = tasks;
            this.dp_deadline.Text = tasks.DeadLine.ToString();
            this.tb_note.Text = tasks.Note;
            this._OCTasks = OCtasks;
            this._position = this._OCTasks.IndexOf(tasks);
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            this.tasks.DeadLine = Convert.ToDateTime(this.dp_deadline.Text);
            this.tasks.Note = this.tb_note.Text;
            DB.EditTask(this.tasks);
            this._OCTasks[this._position] = tasks;
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
