using CommunityToolkit.Mvvm.Input;
using LAP.Resource;
using LAP.ViewModels;

namespace LAP
{
    public class MainViewModel : ViewModel
    {
        public MainViewModel(INavigationManager navigation)
        {
            Navigation = navigation;

            NavigateToQueryTabViewCommand = new RelayCommand(() => Navigation.NavigateTo<QueryTabViewModel>());
            NavigateToSettingsViewCommand = new RelayCommand(() => Navigation.NavigateTo<SettingsViewModel>());

            //Note: CurrentViewModel get's set
            NavigateToQueryTabViewCommand.Execute(null);
        }

        #region Boilerplate
        #region Navigation
        private INavigationManager _navigation;

        public INavigationManager Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }

        public IRelayCommand NavigateToQueryTabViewCommand { get; }
        public IRelayCommand NavigateToSettingsViewCommand { get; }
            #endregion
        #endregion
    }
}
