using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : UserControl
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            var myWindow = Window.GetWindow(this);

            if (tb_password1.Password == tb_password2.Password && tb_mail.Text != "" && tb_pseudo.Text != "")
            {
                Users user = DB.GetCurrentUser(tb_pseudo.Text, tb_password1.Password);
                Thread.Sleep(300);
                if (user == null)
                {
                    DB.AddUser(tb_pseudo.Text, tb_mail.Text, tb_password1.Password);
                    Thread.Sleep(300);
                    Users users = DB.GetCurrentUser(tb_pseudo.Text, tb_password1.Password);
                    if (users != null)
                    {
                        Session.CurrentUser = users;
                        Window window_ToDoList = new ToDoList();
                        myWindow.Close();
                        window_ToDoList.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Error server");
                    }
                }      
                else
                {
                    MessageBox.Show("Already taken");
                }
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
