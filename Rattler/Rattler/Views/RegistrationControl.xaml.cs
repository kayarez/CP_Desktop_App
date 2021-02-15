using Rattler.Controller;
using Rattler.Models;
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

namespace Rattler.Views
{
    /// <summary>
    /// Логика взаимодействия для RegistrationControl.xaml
    /// </summary>
    public partial class RegistrationControl : UserControl
    {
        public RegistrationControl()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            RegistrationController controller = new RegistrationController();
            if (txtPassword.Password.Length >=6 && txtPassword.Password == txtPasswordRepeat.Password)
            {
                User user = new User(txtUsername.Text, txtPassword.Password, txtUserEmail.Text);
                controller.Register(user);
                if (new LoginControl().login(user))
                {
                    EntryWindow parentWindow = Window.GetWindow(this) as EntryWindow;
                    parentWindow.Close();
                }
            }
            else
            {
                MessageBox.Show("Пароли не совпадают или короткий пароль.");
            }
        }
    }
}
