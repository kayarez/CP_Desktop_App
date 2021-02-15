using Rattler.ViewModels;
using System;
using System.Windows.Input;

namespace Rattler.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainViewModel viewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Registration")
            {
                viewModel.SelectedViewModel = new RegistrationViewModel();
            }

            else if (parameter.ToString() == "Login")
            {
                viewModel.SelectedViewModel = new LoginViewModel();
            }
        }
    }
}
