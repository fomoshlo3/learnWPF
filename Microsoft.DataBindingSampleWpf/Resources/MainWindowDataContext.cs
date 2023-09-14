using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Microsoft.DataBindingSampleWpf.Resources
{
    /// <summary>
    /// general approach for setting the DataContext on an UI
    /// in contradiction to setting it for each single control.
    /// </summary>
    public class MainWindowDataContext : INotifyPropertyChanged
    {
        public string? UserName { get; set; }

        /// <summary>
        /// Setting the visibility in code
        /// </summary>
        public Visibility GreetingVisibility => IsNameNeeded ? Visibility.Collapsed : Visibility.Visible;

        public event PropertyChangedEventHandler? PropertyChanged;

        private bool _isNameNeeded = true;

        /// <summary>
        /// Logic for indicating whether the user's name is still needed, Invokes the PropertyChanged event and notifies
        /// the UI to refresh the values for the binding of IsNameNeeded(in XAML code[MainWindow.xaml: line 36, char 21])
        /// and GreetingVisibility
        /// 
        /// This is following the standard-pattern for the INotifyPropertyChanged Interface:
        /// [] Verify whether the value has changed
        /// [] if so , set the new value
        /// [] Notify the UI
        /// </summary>
        public bool IsNameNeeded
        {
            get { return _isNameNeeded; }
            set
            {
                if (value != _isNameNeeded)
                {
                    _isNameNeeded = value;
                    PropertyChanged?.Invoke(
                        this, new PropertyChangedEventArgs(nameof(IsNameNeeded)));
                    PropertyChanged?.Invoke(
                        this, new PropertyChangedEventArgs(nameof(GreetingVisibility)));
                }
            }
        }

        public MainWindowDataContext() { }

    }
}
