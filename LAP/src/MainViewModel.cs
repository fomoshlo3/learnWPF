using CommunityToolkit.Mvvm.Input;
using LAP.src.Resource;
using LAP.src.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAP.src
{
    public class MainViewModel : ViewModel
    {
        public MainViewModel(INavigationManager navigation)
        {
            Navigation = navigation;

            NavigateToQueryTabViewCommand = new RelayCommand(() => Navigation.NavigateTo<QueryTabViewModel>());
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

        private IRelayCommand NavigateToQueryTabViewCommand;

            #endregion
        #endregion
    }
}
