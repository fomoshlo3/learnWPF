using CommunityToolkit.Mvvm.ComponentModel;
using LAP.src.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAP.src.Resource
{
    public interface INavigationManager
    {
        ViewModel CurrentViewModel { get; }

        void NavigateTo<TViewModel>() where TViewModel : ViewModel;
    }

    public class NavigationManager : ObservableObject, INavigationManager
    {
        public NavigationManager(Func<Type, ViewModel> viewModelFactory)
        {
                _viewModelFactory = viewModelFactory;
        }
        private readonly Func<Type, ViewModel> _viewModelFactory;

        private ViewModel _currentViewModel;
        public ViewModel CurrentViewModel
        {
            get => _currentViewModel;
            private set
            {
                _currentViewModel?.Dispose();
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public void NavigateTo<TViewModel>() where TViewModel : ViewModel
        {
           _viewModelFactory.Invoke(typeof(TViewModel));
        }
    }
}
