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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToDoListDLL;

namespace TrelloWPF.UserControls
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : UserControl
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            var identifiant = this.tb_mail.Text;
            var pwd = this.tb_password1.Text;
            Users users = DB.GetCurrentUser(identifiant, pwd);

            if (users != null)
            {
                Window window_ToDoList = new ToDoList();
                myWindow.Close();
                window_ToDoList.ShowDialog();
            }   
            else
            {
                MessageBox.Show("Error with values");
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }
    }
}
