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
using TrelloWPF.UserControls;

namespace TrelloWPF
{
    /// <summary>
    /// Interaction logic for Connection.xaml
    /// </summary>
    public partial class Connection : Window
    {
        public Connection(string type)
        {
            InitializeComponent();
            if (type == "SignIn")
            {
                ExecuteUserControl(new SignIn());
            }
            else if(type == "SignUp")
            {
                ExecuteUserControl(new SignUp());
            }
            else
            {
                this.Close();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ExecuteUserControl(UserControl UC)
        {
            this.Grid_Main.Children.Clear();
            this.Grid_Main.Children.Add(UC);
        }
    }
}
