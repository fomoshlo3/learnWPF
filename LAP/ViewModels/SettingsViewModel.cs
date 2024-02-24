using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LAP.Resource;

namespace LAP.ViewModels
{
    public class SettingsViewModel : ViewModel
    {
        public SettingsViewModel(INavigationManager navigation)
        {
            Navigation = navigation;
            NavigateToQueryTabViewCommand = new RelayCommand(()=> Navigation.NavigateTo<QueryTabViewModel>());
        }

        #region Boilerplate
        #region Navigation
       
        private INavigationManager _navigation;

        public INavigationManager Navigation
        {
            get => _navigation;
            private set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }


        public IRelayCommand NavigateToQueryTabViewCommand;
        #endregion
        #endregion
    }
}