using Rattler.ViewModels;
using System;
using System.Windows.Input;

namespace Rattler.Commands
{
    class AdminViewCommand:ICommand
    {
        private AdminViewModel viewModel;

        public AdminViewCommand(AdminViewModel viewModel1)
        {
            this.viewModel = viewModel1;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Train")
            {
                viewModel.SelectedViewModel = new TrainViewModel();
            }

            else if (parameter.ToString() == "Trip")
            {
                viewModel.SelectedViewModel = new TripViewModel();
            }
            else if(parameter.ToString() == "Order")
            {
                viewModel.SelectedViewModel = new OrderViewModel();
            }

        }
    }
}
