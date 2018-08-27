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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TrelloWPF.UserControls;

namespace TrelloWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            if (Session.CurrentUser != null)
            {
                Window window_toDoList = new ToDoList();
                window_toDoList.ShowDialog();
            }
            else
            {
                Window Window_SignIn = new Connection("SignIn");
                Window_SignIn.ShowDialog();
            }

        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            Window Window_SignUp = new Connection("SignUp");
            Window_SignUp.ShowDialog();
        }
    }
}
