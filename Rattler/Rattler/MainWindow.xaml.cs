using Rattler.Controller;
using Rattler.Models;
using Rattler.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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

namespace Rattler
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static DataGrid datagrid;
        User currentUser;
        string date;

        public MainWindow(User user)
        {

            currentUser = user;
            InitializeComponent();
            Title = user.Login;
        }


        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (SearchPlaceDepartureTextBox.Text != "" || SearchPlaceArrivalTextBox.Text != "")
            {
                MyDbContext context = new MyDbContext();
                List<Trip> gg = context.Trips.Include(p => p.Train).ToList();
                List<Trip> ended = new List<Trip>();
                string str = SearchPlaceDepartureTextBox.Text;
                string str1 = SearchPlaceArrivalTextBox.Text;
                var toD1 = from f in gg where f.PlaceDeparture.Contains($"{str}") select f;
                var toD2 = from f in toD1 where f.PlaceArrival.Contains($"{str1}") select f;
                foreach (var item in toD2)
                {
                    ended.Add(item);
                    
                }

                if (ended.Count ==0)
                {
                    MessageBox.Show("Данный рейс не найден.");
                }

                tripDataGrid.ItemsSource = ended;
            }
            else
            {
                MessageBox.Show("Введите данные для поиска.");
            }

        }

        List<Trip> tripListToBasket = new List<Trip>();

        List<Trip> trips = new List<Trip>();

        public List<Trip> TripToMain
        {
            get { return trips; }
        }


        private void resultDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                using (MyDbContext context = new MyDbContext())
                {
                    Trip trip = tripDataGrid.SelectedItem as Trip;

                    Trip tripCopy = (Trip)trip.Clone();
                    if (trip.NumberSeats != 0)
                    {
                        try
                        {
                            trip.NumberSeats = trip.NumberSeats - 1;
                            tripCopy.NumberSeats = 1;
                            BasketDataGrid.Items.Add(tripCopy);
                            trips.Add(trip);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"{ex.Message}");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Билеты закончились.");
                    }
                }
            }
        }

        private void returnDataRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (sender != null)
            {
                using (MyDbContext context = new MyDbContext())
                {
                    try
                    {
                        Trip trip = BasketDataGrid.SelectedItem as Trip;
                        var fromDBTrip = context.Trips.Single(x => x.Id == trip.Id);
                        foreach (var item in trips)
                        {
                            if (item.Id == fromDBTrip.Id)
                            {
                                trips.Remove(item);
                                break;
                            }
                        }

                        var changeNumberSeats = (List<Trip>)tripDataGrid.ItemsSource;
                        foreach (var item in changeNumberSeats)
                        {
                            if (fromDBTrip.Id == item.Id)
                            {
                                item.NumberSeats = item.NumberSeats + 1;
                            }
                        }
                        tripListToBasket.Remove(trip);
                        BasketDataGrid.Items.Remove(BasketDataGrid.SelectedItem);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}");
                    }

                }

            }
        }

        private void Order_Click(object sender, RoutedEventArgs e)

        {

            var forOrderList = trips;


            if (forOrderList.Count != 0)
            {
                    OrderFormWindow orderForm = new OrderFormWindow(forOrderList);
                    orderForm.Show();
                    Check();
            }
            else
            {
                MessageBox.Show("Корзина пуста.");
            }
        }

        private bool Check()
        {
            using (MyDbContext context = new MyDbContext())
            {
                foreach (Trip t in trips)
                {
                    Trip trip = context.Trips.Find(t.Id);
                    if (trip != null)
                    {
                        trip.NumberSeats--;
                        context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Рейс отменен.");

                    }
                }
            }

            return false;
        }
    }
}
