using Rattler.Controller;
using Rattler.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data.Entity;


namespace Rattler.Views
{
    /// <summary>
    /// Логика взаимодействия для TripControl.xaml
    /// </summary>
    public partial class TripControl : UserControl
    {
        MyDbContext context = new MyDbContext();
        public TripControl()
        {
            InitializeComponent();
            List<Trip> trips  = context.Trips.Include(p => p.Train).ToList();
            TripDataGrid.ItemsSource = trips;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            MyDbContext context = new MyDbContext();
            TripController tripController = new TripController();
            if (double.TryParse(txtCost.Text, out double cost) == true && int.TryParse(txtNumberSeats.Text, out int number) == true
                && int.TryParse(txtPlaceDepartment.Text,out int departure) == false 
                && int.TryParse(txtPlaceArrival.Text, out int arrival) == false) 
            {
                double costTrip = double.Parse(txtCost.Text);
                int numberSeats = int.Parse(txtNumberSeats.Text);
                Trip trip = new Trip(dateDeparture.SelectedDate, dateArrival.SelectedDate, txtPlaceDepartment.Text, txtPlaceArrival.Text, costTrip, int.Parse(txtNumberSeats.Text), txtNumberTrain.Text, txtType.Text);

                if (tripController.AddTrip(trip))
                {
                    MessageBox.Show("Рейс успешно добавлен.");
                    TripDataGrid.ClearValue(ItemsControl.ItemsSourceProperty);
                    List<Trip> trips = context.Trips.Include(tr => tr.Train).ToList();
                    TripDataGrid.ItemsSource = trips;
                }
                else
                {
                    MessageBox.Show("Этот рейс уже существует или введенные данные имеют неверный формат.");
                }
            }
            else
            {
                MessageBox.Show("Неверный формат данных");
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MyDbContext context = new MyDbContext();
                TripController tripController = new TripController();
                Trip trip = TripDataGrid.SelectedItem as Trip;
                if (TripDataGrid.SelectedItem != null)
                {
                    context.Trips.Attach(trip);
                    tripController.RemoveTrip(trip);
                    MessageBox.Show("Рейс успешно удален.");
                }
                TripDataGrid.ClearValue(ItemsControl.ItemsSourceProperty);
                List<Trip> trips = context.Trips.Include(tr => tr.Train).ToList();
                TripDataGrid.ItemsSource = trips;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                context.SaveChanges();
                TripDataGrid.ClearValue(ItemsControl.ItemsSourceProperty);
                List<Trip> trips = context.Trips.ToList();
                TripDataGrid.ItemsSource = trips;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
