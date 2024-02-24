using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LAP.Data.Entities;
using LAP.Resource;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAP.ViewModels
{
    public class QueryTabViewModel : ViewModel
    {
        public QueryTabViewModel(INavigationManager navigation)
        {
            Navigation = navigation;
            NavigateToSettingsViewCommand = new RelayCommand(() => Navigation.NavigateTo<SettingsViewModel>());
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
     

        public IRelayCommand NavigateToSettingsViewCommand;
            #endregion
        #endregion
    }
}
