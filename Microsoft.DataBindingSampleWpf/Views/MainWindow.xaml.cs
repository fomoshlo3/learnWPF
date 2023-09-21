
using Microsoft.DataBindingSampleWpf.ViewModels;
using System.Windows;

namespace Microsoft.DataBindingSampleWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml, 
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Convenience property for easier access to the MainWindowDataContext
        /// 
        /// FrameworkElement.DataContext is designed so that it can be applied to the entire XAML Tree or just part of it.
        /// Gets inherited throughout the XAML tree.
        /// In this example we inject the MainWindowDataContext class and
        /// cast the FrameworkElement.DataContext property with it.
        /// </summary>
        private MainWindowDataContext DC => (MainWindowDataContext)DataContext;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnSubmit_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show($"Hello {DC.UserName}!");
            if (string.IsNullOrWhiteSpace(DC.UserName))
            {
                return;
            }

            DC.IsNameNeeded = false;
        }
    }
}
