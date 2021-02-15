using MaterialDesignColors.Recommended;
using Rattler.Controller;
using Rattler.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    /// Логика взаимодействия для OrderControl.xaml
    /// </summary>
    public partial class OrderControl : UserControl
    {
        string sendMail;
        string order;
        string date;
        string adminMail;
        DataGridRow rowSelect;

        MyDbContext context = new MyDbContext();
        public OrderControl()
        {
            InitializeComponent();
            context.Orders.Load();
            List<Order> orders = context.Orders.Include(r => r.User).ToList();
            OrderDataGrid.ItemsSource = orders;
            adminMail = context.Users.First(admin => admin.Id == 1).Email;
        }

        private void DataGrid_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            TextBlock IdOrder = OrderDataGrid.Columns[1].GetCellContent(row) as TextBlock;
            TextBlock tbl = OrderDataGrid.Columns[2].GetCellContent(row) as TextBlock;
            TextBlock DateOrder = OrderDataGrid.Columns[3].GetCellContent(row) as TextBlock;
            order = IdOrder.Text;
            sendMail = tbl.Text;
            date = DateOrder.Text;
            rowSelect = row;
        }

        private void ChangeState()
        {
            if (rowSelect != null)
            {
                TextBlock idOrderBlock = OrderDataGrid.Columns[1].GetCellContent(rowSelect) as TextBlock;
                int idOrder = Int32.Parse(idOrderBlock.Text);
                using (MyDbContext context = new MyDbContext())
                {
                    try
                    {
                        Order orderChangeState = context.Orders.First(order => order.Id == idOrder);
                        orderChangeState.States = Order.State.Done;
                        OrderDataGrid.ClearValue(ItemsControl.ItemsSourceProperty);
                        List<Order> orders = context.Orders.Include(r => r.User).ToList();
                        OrderDataGrid.ItemsSource = orders;
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}");
                    }
                }
            }
        }


        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            if (rowSelect != null)
            {
                TextBlock stateOrderBlock = OrderDataGrid.Columns[4].GetCellContent(rowSelect) as TextBlock;
                if (stateOrderBlock.Text != "Done")
                {
                    if (sendMail != null)
                    {
                       
                            MailAddress mailAddressFrom = new MailAddress(adminMail, "Rattler");
                            MailAddress mailAddressTo = new MailAddress(sendMail);

                            MailMessage message = new MailMessage(mailAddressFrom, mailAddressTo);

                            message.Subject = "Оповещение о выполнении заказа";
                            message.Body = $"Ваш заказ успешно выполнен. Дата заказа - {date}. Номер заказа - {order}.";
                            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
                            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                            smtp.UseDefaultCredentials = false;
                            smtp.EnableSsl = true;
                            smtp.Credentials = new NetworkCredential(adminMail, "Primitekursach");
                            try
                            {
                              smtp.Send(message);
                              MessageBox.Show("Сообщение отправлено.");
                              ChangeState();
                              
                            }
                            catch (Exception ex)
                            {
                              MessageBox.Show($"{ex.Message}");
                            }
                            finally
                            {
                             rowSelect = null;
                            }
                        
                    }
                    else
                        MessageBox.Show("Что-то пошло не так");
                }
                else
                {
                    MessageBox.Show("Заказ уже выполнен");
                    rowSelect = null;
                }
            }
            else
            {
                MessageBox.Show("Нажмите дважды на выбранный заказ");
                rowSelect = null;
            }
        }
    }
}
