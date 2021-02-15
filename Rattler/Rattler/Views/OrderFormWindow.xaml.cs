using Rattler.Controller;
using Rattler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace Rattler.Views
{
    /// <summary>
    /// Логика взаимодействия для OrderFormWindow.xaml
    /// </summary>

    public partial class OrderFormWindow : Window
    {

        public List<Trip> tripToOrder = new List<Trip>();

        public OrderFormWindow(List<Trip> _trip)
        {
            InitializeComponent();
            tripToOrder = _trip;

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
        private void ClearDataGridFromMain()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).BasketDataGrid.ClearValue(ItemsControl.ItemsSourceProperty);
                    (window as MainWindow).TripToMain.Clear();
                    (window as MainWindow).BasketDataGrid.Items.Clear();
                    (window as MainWindow).BasketDataGrid.Items.Refresh();
                }
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            using (MyDbContext context = new MyDbContext())
            {
                User userAgain = context.Users.FirstOrDefault(User => User.Email == EmailAgain.Text);
                if (userAgain != null)
                {
                    if (userAgain.Password == ComputeSha256Hash(PasswordAgain.Password))
                    {
                        if (Name.Text != "" && Passport.Text.Length >= 8 && Passport.Text != "")
                        {
                            List<Ticket> orderTickets = new List<Ticket>();
                            Order order = new Order();
                            order.Id = 1;
                            for (int i = 0; i < tripToOrder.Count; i++)
                            {
                                orderTickets.Add(new Ticket(Name.Text, Passport.Text, tripToOrder[i].Id, order.Id));
                            }

                            order.Date = DateTime.Now;
                            order.Tickets = orderTickets;                          
                            userAgain.Orders.Add(order);
                            context.SaveChanges();
                            ClearDataGridFromMain();
                            OrderFormWindow parentWindow = Window.GetWindow(this) as OrderFormWindow;
                            MessageBox.Show("Заказ оформлен.");
                            parentWindow.Close();
                        }
                        else
                        {
                            MessageBox.Show("Введите ФИО и паспортные данные.");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Проверьте введенный пароль.");
                    }
                }
                else
                {
                    MessageBox.Show("Проверьте введенный Email.");
                }
            }
        }
    }

}
