using Rattler.Controller;
using Rattler.Models;
using Sitecore.FakeDb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для TrainControl.xaml
    /// </summary>
    public partial class TrainControl : UserControl
    {

        MyDbContext context = new MyDbContext();
        public TrainControl()
        {
            InitializeComponent();
            context.Trains.Load();
            BindingList<Train> trains = context.Trains.Local.ToBindingList();
            TrainDataGrid.ItemsSource = trains;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MyDbContext context = new MyDbContext();
                TrainController trainController = new TrainController();
                Train train = new Train(txtTrainType.Text, txtNumberTrain.Text);

                if (trainController.AddTrain(train))
                {
                    MessageBox.Show("Поезд успешно добавлен.");
                    TrainDataGrid.ClearValue(ItemsControl.ItemsSourceProperty);
                    List<Train> trains = context.Trains.ToList();
                    TrainDataGrid.ItemsSource = trains;
                }
                else
                {
                    MessageBox.Show("Этот поезд уже существует или введенные данные имеют неверный формат.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MyDbContext context = new MyDbContext();
                TrainController trainController = new TrainController();
                Train train = TrainDataGrid.SelectedItem as Train;
                if(TrainDataGrid.SelectedItem!=null)
                {
                    context.Trains.Attach(train);
                    trainController.RemoveTrain(train);
                    MessageBox.Show("Поезд успешно удален.");
                }
                TrainDataGrid.ClearValue(ItemsControl.ItemsSourceProperty);
                List<Train> trains = context.Trains.ToList();
                TrainDataGrid.ItemsSource = trains;
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
                TrainDataGrid.ClearValue(ItemsControl.ItemsSourceProperty);
                List<Train> trains = context.Trains.ToList();
                TrainDataGrid.ItemsSource = trains;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

