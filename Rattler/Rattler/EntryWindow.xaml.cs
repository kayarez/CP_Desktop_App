using Rattler.Controller;
using Rattler.Models;
using Rattler.ViewModels;
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

namespace Rattler
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class EntryWindow : Window
    {
        public EntryWindow()
        {
            InitializeComponent();
            MyDbInitialize myDbInitializer = new MyDbInitialize();
            MyDbContext context = new MyDbContext();
            myDbInitializer.InitializeDatabase(context);
            DataContext = new MainViewModel();
        }
    }
}
