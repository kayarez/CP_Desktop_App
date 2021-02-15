using Rattler.Controller;
using Rattler.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace Rattler.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginControl.xaml
    /// </summary>
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
        }
        public bool login(User user)
        {
            try
            {
                LoginController controller = new LoginController();
                User loginUser = controller.Login(user);
                User loginAdmin = controller.Admin(user);
                if (loginUser != null)
                {
                    MainWindow window = new MainWindow(loginUser);
                    window.Show();
                    return true;

                }
                else if(loginAdmin!=null)
                {
                    AdminWindow window = new AdminWindow();
                    window.Show();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        static public string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.Login = txtUsername.Text;
            user.Password = ComputeSha256Hash(txtPassword.Password);
            if (login(user))
            {
                EntryWindow parentWindow = Window.GetWindow(this) as EntryWindow;
                parentWindow.Close();
            }
            else
            {
                MessageBox.Show("Логин или пароль введены неверно");
            }
        }

    }
}
