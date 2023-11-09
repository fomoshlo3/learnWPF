using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppNavigationbyUWPNavService
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Page1Button_OnClick(object sender, RoutedEventArgs e)
        {
            // The Page uses the parent NavigationWindow's NavigationService.
            // Use that NavigationService's Navigate method with a relative URI to go to another Page.
            NavigationService?.Navigate(new Uri("Page1.xaml", UriKind.Relative));
        }
    }
}
