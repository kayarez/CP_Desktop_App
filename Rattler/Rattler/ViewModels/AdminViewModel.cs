using Rattler.Commands;
using System.Windows.Input;

namespace Rattler.ViewModels
{
    public class AdminViewModel: BaseViewModel
    {
		private BaseViewModel _selectedViewModel = new TrainViewModel();

		public BaseViewModel SelectedViewModel
		{
			get { return _selectedViewModel; }
			set
			{
				_selectedViewModel = value;
				OnPropertyChanged(nameof(SelectedViewModel));
			}
		}

		public ICommand AdminViewCommand { get; set; }

		public AdminViewModel()
		{
			AdminViewCommand = new AdminViewCommand(this);
		}
	}
}
